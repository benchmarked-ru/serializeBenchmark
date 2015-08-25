using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace serializeBenchmarks.Serializers
{
    class Protobuf : ISerializer
    {
        public byte[] Serialize<T>(object obj)
        {
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, (T)obj);
                return ms.ToArray();
            }
        }

        public T Deserialize<T>(byte[] data)
        {
            using (var stream = new MemoryStream(data))
            {
                stream.Seek(0, SeekOrigin.Begin);
                return Serializer.Deserialize<T>(stream);
            }
        }
    }
}
