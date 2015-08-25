using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serializeBenchmarks
{
    class Tester
    {
        public static void Test(IDictionary<string, ISerializer> serializers)
        {
            foreach (var serializer in serializers)
            {
                var model = DataPreparer.GenerateModel(1, 10);

                var s = serializer.Value;
                var data = s.Serialize<Model>(model);
                var deserialized = s.Deserialize<Model>(data);
                model.Compare(deserialized);
            }
        }
    }
}
