using System;
using System.IO;
using System.Runtime.Serialization;

namespace serializeBenchmarks.Serializers
{
    class DataContract : ISerializer
    {
        private readonly DataContractSerializer serializer;

        public DataContract(Type t)
        {
            serializer = new DataContractSerializer(t);
        }

        public byte[] Serialize<T>(object obj)
        {
            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, (T)obj);
                return stream.ToArray();
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
