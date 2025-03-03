import { TypeSpecDecorators } from "../../generated-defs/TypeSpec.js";
import {
  $discriminator,
  $doc,
  $encode,
  $encodedName,
  $error,
  $errorsDoc,
  $example,
  $format,
  $friendlyName,
  $inspectType,
  $inspectTypeName,
  $key,
  $knownValues,
  $maxItems,
  $maxLength,
  $maxValue,
  $maxValueExclusive,
  $minItems,
  $minLength,
  $minValue,
  $minValueExclusive,
  $opExample,
  $overload,
  $pattern,
  $projectedName,
  $returnsDoc,
  $secret,
  $service,
  $summary,
  $tag,
  $withOptionalProperties,
  $withPickedProperties,
  $withoutDefaultValues,
  $withoutOmittedProperties,
  discriminatedDecorator,
} from "./decorators.js";
import {
  continuationTokenDecorator,
  firstLinkDecorator,
  lastLinkDecorator,
  listDecorator,
  nextLinkDecorator,
  offsetDecorator,
  pageIndexDecorator,
  pageItemsDecorator,
  pageSizeDecorator,
  prevLinkDecorator,
} from "./paging.js";
import {
  $defaultVisibility,
  $invisible,
  $parameterVisibility,
  $removeVisibility,
  $returnTypeVisibility,
  $visibility,
  $withDefaultKeyVisibility,
  $withLifecycleUpdate,
  $withUpdateableProperties,
  $withVisibility,
  $withVisibilityFilter,
} from "./visibility.js";

/** @internal */
export const $decorators = {
  TypeSpec: {
    encode: $encode,
    doc: $doc,
    withOptionalProperties: $withOptionalProperties,
    withUpdateableProperties: $withUpdateableProperties,
    withoutOmittedProperties: $withoutOmittedProperties,
    withPickedProperties: $withPickedProperties,
    withoutDefaultValues: $withoutDefaultValues,
    summary: $summary,
    returnsDoc: $returnsDoc,
    errorsDoc: $errorsDoc,
    service: $service,
    error: $error,
    format: $format,
    pattern: $pattern,
    minLength: $minLength,
    maxLength: $maxLength,
    minItems: $minItems,
    maxItems: $maxItems,
    minValue: $minValue,
    maxValue: $maxValue,
    minValueExclusive: $minValueExclusive,
    maxValueExclusive: $maxValueExclusive,
    secret: $secret,
    tag: $tag,
    friendlyName: $friendlyName,
    knownValues: $knownValues,
    key: $key,
    overload: $overload,
    projectedName: $projectedName,
    encodedName: $encodedName,
    discriminated: discriminatedDecorator,
    discriminator: $discriminator,
    example: $example,
    opExample: $opExample,
    inspectType: $inspectType,
    inspectTypeName: $inspectTypeName,
    visibility: $visibility,
    removeVisibility: $removeVisibility,
    invisible: $invisible,
    defaultVisibility: $defaultVisibility,
    withVisibility: $withVisibility,
    withVisibilityFilter: $withVisibilityFilter,
    withLifecycleUpdate: $withLifecycleUpdate,
    withDefaultKeyVisibility: $withDefaultKeyVisibility,
    parameterVisibility: $parameterVisibility,
    returnTypeVisibility: $returnTypeVisibility,

    list: listDecorator,
    offset: offsetDecorator,
    pageIndex: pageIndexDecorator,
    pageSize: pageSizeDecorator,
    pageItems: pageItemsDecorator,
    continuationToken: continuationTokenDecorator,
    nextLink: nextLinkDecorator,
    prevLink: prevLinkDecorator,
    firstLink: firstLinkDecorator,
    lastLink: lastLinkDecorator,
  } satisfies TypeSpecDecorators,
};

// Projection function exports
export const namespace = "TypeSpec";
export { getProjectedName, hasProjectedName } from "./decorators.js";
