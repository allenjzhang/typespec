// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;
using System.Threading.Tasks;

namespace Versioning.MadeOptional
{
    public partial class MadeOptionalClient
    {
        protected MadeOptionalClient() => throw null;

        public MadeOptionalClient(Uri endpoint) : this(endpoint, new MadeOptionalClientOptions()) => throw null;

        public MadeOptionalClient(Uri endpoint, MadeOptionalClientOptions options) => throw null;

        public ClientPipeline Pipeline => throw null;

        public virtual ClientResult Test(BinaryContent content, string @param = default, RequestOptions options = null) => throw null;

        public virtual Task<ClientResult> TestAsync(BinaryContent content, string @param = default, RequestOptions options = null) => throw null;

        public virtual ClientResult<TestModel> Test(TestModel body, string @param = default, CancellationToken cancellationToken = default) => throw null;

        public virtual Task<ClientResult<TestModel>> TestAsync(TestModel body, string @param = default, CancellationToken cancellationToken = default) => throw null;
    }
}
