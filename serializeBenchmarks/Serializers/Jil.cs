using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jil;

namespace serializeBenchmarks.Serializers
{
    class Jil : ISerializer
    {
        public byte[] Serialize<T>(object obj)
        {
            var str =  JSON.Serialize<T>((T)obj);
            return Encoding.ASCII.GetBytes(str);
        }

        public T Deserialize<T>(byte[] data)
        {
            var str = Encoding.ASCII.GetString(data);
            return JSON.Deserialize<T>(str);
        }
    }
}
