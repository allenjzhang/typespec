// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.TypeSpec.Generator.Primitives
{
    /// <summary>
    /// The set of validation types to perform on a parameter.
    /// </summary>
    public enum ParameterValidationType
    {
        None,
        AssertNotNull,
        AssertNotNullOrEmpty
    }
}
