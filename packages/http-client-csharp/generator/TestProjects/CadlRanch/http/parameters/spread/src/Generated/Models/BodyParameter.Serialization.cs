// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Parameters.Spread._Model
{
    public partial class BodyParameter : IJsonModel<BodyParameter>
    {
        void IJsonModel<BodyParameter>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw null;

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw null;

        BodyParameter IJsonModel<BodyParameter>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;

        protected virtual BodyParameter JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;

        BinaryData IPersistableModel<BodyParameter>.Write(ModelReaderWriterOptions options) => throw null;

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => throw null;

        BodyParameter IPersistableModel<BodyParameter>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;

        protected virtual BodyParameter PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options) => throw null;

        string IPersistableModel<BodyParameter>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;

        public static implicit operator BinaryContent(BodyParameter bodyParameter) => throw null;

        public static explicit operator BodyParameter(ClientResult result) => throw null;
    }
}
