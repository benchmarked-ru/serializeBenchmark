using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace serializeBenchmarks.Serializers
{
    class Json : ISerializer
    {

        private readonly DataContractJsonSerializer serializer;

        public Json(Type obj)
        {
            serializer = new DataContractJsonSerializer(obj);
        }

        public byte[] Serialize<T>(object obj)
        {
            using (var sw = new MemoryStream())
            {
                serializer.WriteObject(sw, (T)obj);
                return sw.ToArray();
            }
        }

        public T Deserialize<T>(byte[] data)
        {
            using (var stream = new MemoryStream(data))
            {
                stream.Seek(0, SeekOrigin.Begin);
                return (T)serializer.ReadObject(stream);
            }
        }
    }
}
