using System;
using System.IO;
using System.Xml.Serialization;

namespace serializeBenchmarks.Serializers
{
    class Xml : ISerializer
    {
        private readonly XmlSerializer serializer;

        public Xml(Type obj)
        {
            serializer = new XmlSerializer(obj);
        }

        public byte[] Serialize<T>(object obj)
        {
            using (var sw = new MemoryStream())
            {
                serializer.Serialize(sw, (T)obj);
                return sw.ToArray();
            }
        }

        public T Deserialize<T>(byte[] data)
        {
            using (var sr = new MemoryStream(data))
            {
                return (T)serializer.Deserialize(sr);
            }
        }
    }
}
