using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace serializeBenchmarks.Serializers
{
    class Binary : ISerializer
    {
        private readonly BinaryFormatter serializer = new BinaryFormatter();

        public byte[] Serialize<T>(object obj)
        {
            using (var ms = new MemoryStream())
            {
                serializer.Serialize(ms, (T)obj);
                return ms.ToArray();
            }
        }

        public T Deserialize<T>(byte[] data)
        {
            using (var stream = new MemoryStream(data))
            {
                return (T)serializer.Deserialize(stream);
            }
        }
    }
}
