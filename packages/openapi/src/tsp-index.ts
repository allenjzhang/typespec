import { TypeSpecOpenAPIDecorators } from "../generated-defs/TypeSpec.OpenAPI.js";
import {
  $defaultResponse,
  $extension,
  $externalDocs,
  $info,
  $operationId,
  tagMetadataDecorator,
} from "./decorators.js";

export { $lib } from "./lib.js";

/** @internal */
export const $decorators = {
  "TypeSpec.OpenAPI": {
    defaultResponse: $defaultResponse,
    extension: $extension,
    externalDocs: $externalDocs,
    info: $info,
    operationId: $operationId,
    tagMetadata: tagMetadataDecorator,
  } satisfies TypeSpecOpenAPIDecorators,
};
