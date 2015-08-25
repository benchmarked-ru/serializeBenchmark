using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

namespace serializeBenchmarks
{
    [Serializable]
    [ProtoContract]
    public class Model
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public List<SubModel> SubModels { get; set; }

        public void Compare(Model model)
        {
            Check(Id, model.Id);
            Check(Name, model.Name);
            Check(SubModels.Count, model.SubModels.Count);

            for (var i = 0; i < SubModels.Count; i++)
            {
                var a = SubModels[i];
                var b = model.SubModels[i];

                Check(a.Byte, b.Byte);
                Check(a.Decimal, b.Decimal);
                Check(a.Double, b.Double);
                Check(a.EnumValue, b.EnumValue);
                Check(a.Float, b.Float);
                Check(a.Int, b.Int);
                Check(a.Short, b.Short);
                Check(a.Long, b.Long);
            }
        }

        private void Check<T>(T a, T b)
        {
            if(!a.Equals(b))
                throw new Exception("Values different");
        }
    }

    [Serializable]
    [ProtoContract]
    public class SubModel
    {
        [ProtoMember(1)]
        public byte Byte { get; set; }
        [ProtoMember(2)]
        public short Short { get; set; }
        [ProtoMember(3)]
        public int Int { get; set; }
        [ProtoMember(4)]
        public long Long { get; set; }
        [ProtoMember(5)]
        public float Float { get; set; }
        [ProtoMember(6)]
        public double Double { get; set; }
        [ProtoMember(7)]
        public decimal Decimal { get; set; }
        [ProtoMember(8)]
        public Enum EnumValue { get; set; }
    }

    [Serializable]
    [DataContract]
    [ProtoContract]
    public enum Enum
    {
        [EnumMember]
        [ProtoEnum]
        Value1,
        [EnumMember]
        [ProtoEnum]
        Value2,
        [EnumMember]
        [ProtoEnum]
        Value3,
        [EnumMember]
        [ProtoEnum]
        Value4,
        [EnumMember]
        [ProtoEnum]
        Value5,
        [EnumMember]
        [ProtoEnum]
        Value6,
        [EnumMember]
        [ProtoEnum]
        Value7,
        [EnumMember]
        [ProtoEnum]
        Value8,
        [EnumMember]
        [ProtoEnum]
        Value9,
        [EnumMember]
        [ProtoEnum]
        Value10,
    }
}
