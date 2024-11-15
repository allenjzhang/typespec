// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// Code generated by Microsoft (R) TypeSpec Code Generator.

package client.structure.service.implementation;

import client.structure.service.models.ClientType;
import com.azure.core.annotation.ExpectedResponses;
import com.azure.core.annotation.Host;
import com.azure.core.annotation.HostParam;
import com.azure.core.annotation.Post;
import com.azure.core.annotation.ReturnType;
import com.azure.core.annotation.ServiceInterface;
import com.azure.core.annotation.ServiceMethod;
import com.azure.core.annotation.UnexpectedResponseExceptionType;
import com.azure.core.exception.ClientAuthenticationException;
import com.azure.core.exception.HttpResponseException;
import com.azure.core.exception.ResourceModifiedException;
import com.azure.core.exception.ResourceNotFoundException;
import com.azure.core.http.HttpPipeline;
import com.azure.core.http.HttpPipelineBuilder;
import com.azure.core.http.policy.RetryPolicy;
import com.azure.core.http.policy.UserAgentPolicy;
import com.azure.core.http.rest.RequestOptions;
import com.azure.core.http.rest.Response;
import com.azure.core.http.rest.RestProxy;
import com.azure.core.util.Context;
import com.azure.core.util.FluxUtil;
import com.azure.core.util.serializer.JacksonAdapter;
import com.azure.core.util.serializer.SerializerAdapter;
import reactor.core.publisher.Mono;

/**
 * Initializes a new instance of the FirstClient type.
 */
public final class FirstClientImpl {
    /**
     * The proxy service used to perform REST calls.
     */
    private final FirstClientService service;

    /**
     * Need to be set as 'http://localhost:3000' in client.
     */
    private final String endpoint;

    /**
     * Gets Need to be set as 'http://localhost:3000' in client.
     * 
     * @return the endpoint value.
     */
    public String getEndpoint() {
        return this.endpoint;
    }

    /**
     * Need to be set as 'default', 'multi-client', 'renamed-operation', 'two-operation-group' in client.
     */
    private final ClientType client;

    /**
     * Gets Need to be set as 'default', 'multi-client', 'renamed-operation', 'two-operation-group' in client.
     * 
     * @return the client value.
     */
    public ClientType getClient() {
        return this.client;
    }

    /**
     * The HTTP pipeline to send requests through.
     */
    private final HttpPipeline httpPipeline;

    /**
     * Gets The HTTP pipeline to send requests through.
     * 
     * @return the httpPipeline value.
     */
    public HttpPipeline getHttpPipeline() {
        return this.httpPipeline;
    }

    /**
     * The serializer to serialize an object into a string.
     */
    private final SerializerAdapter serializerAdapter;

    /**
     * Gets The serializer to serialize an object into a string.
     * 
     * @return the serializerAdapter value.
     */
    public SerializerAdapter getSerializerAdapter() {
        return this.serializerAdapter;
    }

    /**
     * The Group3sImpl object to access its operations.
     */
    private final Group3sImpl group3s;

    /**
     * Gets the Group3sImpl object to access its operations.
     * 
     * @return the Group3sImpl object.
     */
    public Group3sImpl getGroup3s() {
        return this.group3s;
    }

    /**
     * The Group4sImpl object to access its operations.
     */
    private final Group4sImpl group4s;

    /**
     * Gets the Group4sImpl object to access its operations.
     * 
     * @return the Group4sImpl object.
     */
    public Group4sImpl getGroup4s() {
        return this.group4s;
    }

    /**
     * Initializes an instance of FirstClient client.
     * 
     * @param endpoint Need to be set as 'http://localhost:3000' in client.
     * @param client Need to be set as 'default', 'multi-client', 'renamed-operation', 'two-operation-group' in client.
     */
    public FirstClientImpl(String endpoint, ClientType client) {
        this(new HttpPipelineBuilder().policies(new UserAgentPolicy(), new RetryPolicy()).build(),
            JacksonAdapter.createDefaultSerializerAdapter(), endpoint, client);
    }

    /**
     * Initializes an instance of FirstClient client.
     * 
     * @param httpPipeline The HTTP pipeline to send requests through.
     * @param endpoint Need to be set as 'http://localhost:3000' in client.
     * @param client Need to be set as 'default', 'multi-client', 'renamed-operation', 'two-operation-group' in client.
     */
    public FirstClientImpl(HttpPipeline httpPipeline, String endpoint, ClientType client) {
        this(httpPipeline, JacksonAdapter.createDefaultSerializerAdapter(), endpoint, client);
    }

    /**
     * Initializes an instance of FirstClient client.
     * 
     * @param httpPipeline The HTTP pipeline to send requests through.
     * @param serializerAdapter The serializer to serialize an object into a string.
     * @param endpoint Need to be set as 'http://localhost:3000' in client.
     * @param client Need to be set as 'default', 'multi-client', 'renamed-operation', 'two-operation-group' in client.
     */
    public FirstClientImpl(HttpPipeline httpPipeline, SerializerAdapter serializerAdapter, String endpoint,
        ClientType client) {
        this.httpPipeline = httpPipeline;
        this.serializerAdapter = serializerAdapter;
        this.endpoint = endpoint;
        this.client = client;
        this.group3s = new Group3sImpl(this);
        this.group4s = new Group4sImpl(this);
        this.service = RestProxy.create(FirstClientService.class, this.httpPipeline, this.getSerializerAdapter());
    }

    /**
     * The interface defining all the services for FirstClient to be used by the proxy service to perform REST calls.
     */
    @Host("{endpoint}/client/structure/{client}")
    @ServiceInterface(name = "FirstClient")
    public interface FirstClientService {
        @Post("/one")
        @ExpectedResponses({ 204 })
        @UnexpectedResponseExceptionType(value = ClientAuthenticationException.class, code = { 401 })
        @UnexpectedResponseExceptionType(value = ResourceNotFoundException.class, code = { 404 })
        @UnexpectedResponseExceptionType(value = ResourceModifiedException.class, code = { 409 })
        @UnexpectedResponseExceptionType(HttpResponseException.class)
        Mono<Response<Void>> one(@HostParam("endpoint") String endpoint, @HostParam("client") ClientType client,
            RequestOptions requestOptions, Context context);

        @Post("/one")
        @ExpectedResponses({ 204 })
        @UnexpectedResponseExceptionType(value = ClientAuthenticationException.class, code = { 401 })
        @UnexpectedResponseExceptionType(value = ResourceNotFoundException.class, code = { 404 })
        @UnexpectedResponseExceptionType(value = ResourceModifiedException.class, code = { 409 })
        @UnexpectedResponseExceptionType(HttpResponseException.class)
        Response<Void> oneSync(@HostParam("endpoint") String endpoint, @HostParam("client") ClientType client,
            RequestOptions requestOptions, Context context);
    }

    /**
     * The one operation.
     * 
     * @param requestOptions The options to configure the HTTP request before HTTP client sends it.
     * @throws HttpResponseException thrown if the request is rejected by server.
     * @throws ClientAuthenticationException thrown if the request is rejected by server on status code 401.
     * @throws ResourceNotFoundException thrown if the request is rejected by server on status code 404.
     * @throws ResourceModifiedException thrown if the request is rejected by server on status code 409.
     * @return the {@link Response} on successful completion of {@link Mono}.
     */
    @ServiceMethod(returns = ReturnType.SINGLE)
    public Mono<Response<Void>> oneWithResponseAsync(RequestOptions requestOptions) {
        return FluxUtil
            .withContext(context -> service.one(this.getEndpoint(), this.getClient(), requestOptions, context));
    }

    /**
     * The one operation.
     * 
     * @param requestOptions The options to configure the HTTP request before HTTP client sends it.
     * @throws HttpResponseException thrown if the request is rejected by server.
     * @throws ClientAuthenticationException thrown if the request is rejected by server on status code 401.
     * @throws ResourceNotFoundException thrown if the request is rejected by server on status code 404.
     * @throws ResourceModifiedException thrown if the request is rejected by server on status code 409.
     * @return the {@link Response}.
     */
    @ServiceMethod(returns = ReturnType.SINGLE)
    public Response<Void> oneWithResponse(RequestOptions requestOptions) {
        return service.oneSync(this.getEndpoint(), this.getClient(), requestOptions, Context.NONE);
    }
}