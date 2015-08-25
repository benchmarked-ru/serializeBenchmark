using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace serializeBenchmarks
{
    internal class Measurer
    {
        public Dictionary<string, long> MeasureTime(Dictionary<string, ISerializer> serializers, int modelsCount)
        {
            var models = DataPreparer.GenerateData(modelsCount);
            var res = new Dictionary<string, long>();
            foreach (var serializer in serializers)
            {
                var sw = new Stopwatch();
                sw.Start();
                foreach (var model in models)
                {
                    var payload = serializer.Value.Serialize<Model>(model);
                    var deserialized = serializer.Value.Deserialize<Model>(payload);
                }
                sw.Stop();
                res[serializer.Key] = sw.ElapsedMilliseconds;
            }
            return res;
        }

        public Dictionary<string, long> MeasureMemory(Dictionary<string, ISerializer> serializers, int modelsCount)
        {
            var model = DataPreparer.GenerateModel(1, modelsCount);
            var res = new Dictionary<string, long>();
            foreach (var serializer in serializers)
            {
                var payload = serializer.Value.Serialize<Model>(model);
                res[serializer.Key] = payload.Length;
            }
            return res;
        }

    }
}