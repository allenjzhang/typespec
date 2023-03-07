#!/usr/bin/env node

/* eslint-disable no-console */
import { MANIFEST, NodePackage, resolvePath } from "@typespec/compiler";
import * as fs from "fs";
import { readFile } from "fs/promises";
import * as semver from "semver";
import yargs from "yargs";
import { migrationConfigurations } from "./migration-config.js";
import {
  migrateFileRename,
  migratePackageVersion,
  migrateTypeSpecFiles,
} from "./migration-impl.js";
import { MigrationKind } from "./migration-types.js";
import { findTypeSpecFiles } from "./utils.js";

interface Options {
  path: string;
  tspVersion: string;
}

async function main() {
  console.log(`TypeSpec migration tool v${MANIFEST.version}\n`);

  const cliOptions: Options = await yargs(process.argv.slice(2))
    .option("path", {
      alias: "p",
      describe: "Path to the input file. Default to current folder.",
      type: "string",
      default: process.cwd(),
    })
    .option("tspVersion", {
      alias: "t",
      describe: "Specifies the version of TypeSpec doc. Default will be loading from package.json",
      type: "string",
      default: "",
    })
    .help().argv;

  const PackageJsonFile = "package.json";
  if (cliOptions.tspVersion.length === 0) {
    // Locate current package.json
    const pkgFile = resolvePath(cliOptions.path, PackageJsonFile);
    const packageJson: NodePackage = JSON.parse(await readFile(pkgFile, "utf-8"));

    // Locate current compiler version
    const CadlCompiler = "@cadl-lang/compiler";
    const TypeSpecCompiler = "@typespec/compiler";
    if (
      packageJson?.devDependencies !== undefined &&
      packageJson?.devDependencies[CadlCompiler] !== undefined
    ) {
      cliOptions.tspVersion = packageJson.devDependencies[CadlCompiler];
    } else if (
      packageJson?.devDependencies !== undefined &&
      packageJson?.devDependencies[TypeSpecCompiler] !== undefined
    ) {
      cliOptions.tspVersion = packageJson.devDependencies[TypeSpecCompiler];
    } else {
      console.error("Unable to find TypeSpec compiler version in package.json.");
      return;
    }
  }

  if (!fs.existsSync(cliOptions.path)) {
    console.error(`Path not found. ${cliOptions.path}`);
    return;
  }

  let changesMake = false;

  // Iterate thru migration configuration and invoke
  console.log(`Current Typespec version ${cliOptions.tspVersion}.`);
  const stepKeys = Object.keys(migrationConfigurations);
  for (const key of stepKeys) {
    if (semver.gt(key, cliOptions.tspVersion)) {
      console.log(
        `Migration step found to upgrade from ${cliOptions.tspVersion} to ${key}. Migrating...`
      );

      for (const migrationStep of migrationConfigurations[key]) {
        switch (migrationStep.kind) {
          case MigrationKind.Content:
            const files = await findTypeSpecFiles(cliOptions.path);
            const result = await migrateTypeSpecFiles(files, migrationStep);
            // If migration has been performed log status
            if (result.fileChanged.length > 0) {
              changesMake = true;
              console.log(`Updated ${result.fileChanged.length} typespec files:`);
              for (const file of result.fileChanged) {
                console.log(` - ${file}`);
              }
            }
            break;
          case MigrationKind.FileRename:
            const srcFiles = await findTypeSpecFiles(cliOptions.path);
            await migrateFileRename(srcFiles, migrationStep);
            break;
          case MigrationKind.PackageVersionUpdate:
            const pkgFile = resolvePath(cliOptions.path, PackageJsonFile);
            await migratePackageVersion(pkgFile, migrationStep);
            break;
          default:
            console.log(`Unexpected error: unknown migration kind: ${migrationStep} `);
        }
      }

      cliOptions.tspVersion = key;
    } else {
      console.log(
        `${cliOptions.tspVersion} is already greater than or equal to ${key}. Migration step skipped...`
      );
    }
  }

  if (changesMake) {
    console.log(
      "\nThis is a best effort migration, double check everything was migrated correctly."
    );
  } else {
    console.log("\nNo typespec files has been migrated.");
  }
}

main().catch((e) => {
  // eslint-disable-next-line no-console
  console.error(e);
  process.exit(1);
});
