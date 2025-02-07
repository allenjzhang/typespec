// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace _Type.Model.Empty
{
    public partial class EmptyInput : IJsonModel<EmptyInput>
    {
        void IJsonModel<EmptyInput>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw null;

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw null;

        EmptyInput IJsonModel<EmptyInput>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;

        protected virtual EmptyInput JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw null;

        BinaryData IPersistableModel<EmptyInput>.Write(ModelReaderWriterOptions options) => throw null;

        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options) => throw null;

        EmptyInput IPersistableModel<EmptyInput>.Create(BinaryData data, ModelReaderWriterOptions options) => throw null;

        protected virtual EmptyInput PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options) => throw null;

        string IPersistableModel<EmptyInput>.GetFormatFromOptions(ModelReaderWriterOptions options) => throw null;

        public static implicit operator BinaryContent(EmptyInput emptyInput) => throw null;

        public static explicit operator EmptyInput(ClientResult result) => throw null;
    }
}
