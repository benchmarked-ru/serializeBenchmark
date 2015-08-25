using System;
using System.IO;
using Thrift.Protocol;
using Thrift.Transport;

namespace serializeBenchmarks.Serializers
{
    internal class Thrift1
    {

        public byte[] Serialize<T>(T obj) where T : TBase
        {
            using (var stream = new MemoryStream())
            {
                TProtocol protocol = new TBinaryProtocol(
                    new TStreamTransport(stream, stream));
                obj.Write(protocol);
                return stream.ToArray();
            }
        }

        public T Deserialize<T>(byte[] data) where T : TBase, new()
        {
            using (var stream = new MemoryStream(data))
            {
                TProtocol protocol = new TBinaryProtocol(
                    new TStreamTransport(stream, stream));
                var t = new T();
                t.Read(protocol);
                return t;
            }
        }
    }
}
