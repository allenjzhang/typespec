// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

package com.microsoft.typespec.http.client.generator.mgmt.model;

public class ResourceTypeName {

    // need a compile-time constant for switch clause
    public static final String RESOURCE = "Resource";
    public static final String AZURE_RESOURCE = "AzureResource";
    public static final String SUB_RESOURCE = "SubResource";
    public static final String PROXY_RESOURCE = "ProxyResource";
    public static final String TRACKED_RESOURCE = "TrackedResource";
    public static final String EXTENSION_RESOURCE = "ExtensionResource";

    private static final String AUTO_GENERATED = "AutoGenerated";
    // these are duplications for above. modelerfour would add "AutoGenerated" to type name, if 2 types having same name
    // but different definition.
    public static final String RESOURCE_AUTO_GENERATED = RESOURCE + AUTO_GENERATED;
    public static final String AZURE_RESOURCE_AUTO_GENERATED = AZURE_RESOURCE + AUTO_GENERATED;
    public static final String SUB_RESOURCE_AUTO_GENERATED = SUB_RESOURCE + AUTO_GENERATED;
    public static final String PROXY_RESOURCE_AUTO_GENERATED = PROXY_RESOURCE + AUTO_GENERATED;
    public static final String TRACKED_RESOURCE_AUTO_GENERATED = TRACKED_RESOURCE + AUTO_GENERATED;

    public static final String FIELD_ID = "id";
    public static final String FIELD_NAME = "name";
    public static final String FIELD_TYPE = "type";
    public static final String FIELD_LOCATION = "location";
    public static final String FIELD_TAGS = "tags";
}
