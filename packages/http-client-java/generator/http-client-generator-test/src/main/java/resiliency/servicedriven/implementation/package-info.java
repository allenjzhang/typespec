// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// Code generated by Microsoft (R) TypeSpec Code Generator.

/**
 * <!-- start generated doc -->
 * Package containing the implementations for ServiceDriven.
 * Test that we can grow up a service spec and service deployment into a multi-versioned service with full client
 * support.
 * 
 * There are three concepts that should be clarified:
 * 1. Client spec version: refers to the spec that the client is generated from. 'v1' is a client generated from old.tsp
 * and 'v2' is a client generated from main.tsp.
 * 2. Service deployment version: refers to a deployment version of the service. 'v1' represents the initial deployment
 * of the service with a single api version. 'v2' represents the new deployment of a service with multiple api versions
 * 3. Api version: The initial deployment of the service only supports api version 'v1'. The new deployment of the
 * service supports api versions 'v1' and 'v2'.
 * 
 * We test the following configurations from this service spec:
 * - A client generated from the second service spec can call the second deployment of a service with api version v1
 * - A client generated from the second service spec can call the second deployment of a service with api version v2.
 * <!-- end generated doc -->
 */
package resiliency.servicedriven.implementation;
