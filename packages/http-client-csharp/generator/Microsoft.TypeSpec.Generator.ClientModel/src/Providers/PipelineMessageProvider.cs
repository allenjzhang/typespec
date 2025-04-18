// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using Microsoft.CodeAnalysis.Classification;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Statements;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Microsoft.TypeSpec.Generator.ClientModel.Providers
{
    internal record PipelineMessageProvider : HttpMessageApi
    {
        public PipelineMessageProvider(ValueExpression original) : base(typeof(PipelineMessage), original)
        {
        }

        private static HttpMessageApi? _instance;
        internal static HttpMessageApi Instance => _instance ??= new PipelineMessageProvider(Empty);

        public override HttpRequestApi Request()
            => new PipelineRequestProvider(Original.Property(nameof(PipelineMessage.Request)));

        public override ValueExpression BufferResponse()
            => Original.Property(nameof(PipelineMessage.BufferResponse));

        public override HttpResponseApi Response()
            => new PipelineResponseProvider(Original.Property(nameof(PipelineMessage.Response)));

        public override MethodBodyStatement ApplyResponseClassifier(StatusCodeClassifierApi statusCodeClassifier)
            => Original.Property(nameof(PipelineMessage.ResponseClassifier)).Assign(statusCodeClassifier).Terminate();

        public override MethodBodyStatement ApplyRequestOptions(HttpRequestOptionsApi options)
            => Original.Invoke(nameof(PipelineMessage.Apply), options).Terminate();

        public override HttpMessageApi FromExpression(ValueExpression original)
            => new PipelineMessageProvider(original);

        public override HttpMessageApi ToExpression()
            => this;

        public override CSharpType HttpMessageType => typeof(PipelineMessage);
    }
}
