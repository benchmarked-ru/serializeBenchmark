using System.Collections.Generic;
using System.Linq;

namespace serializeBenchmarks
{
    public static class DataPreparer
    {
        public static List<Model> GenerateData(int modelsCount)
        {
            return Enumerable.Range(0, modelsCount)
                .Select((i) => GenerateModel(i, 1000)).ToList();
        }

        public static Model GenerateModel(int iteration, int submodelsCount)
        {
            var model = new Model
            {
                Id = iteration,
                Name = "Name" + iteration,
                SubModels = GenerateSubModels(submodelsCount)
            };
            return model;
        }

        private static List<SubModel> GenerateSubModels(int submodelsCount)
        {
            var res = new List<SubModel>();
            for (int i = 0; i < submodelsCount; i++)
            {
                var sub = new SubModel
                {
                    Short = (short)i,
                    Long = i,
                    EnumValue = Enum.Value1,
                    Float = i,
                    Byte = (byte)(i % 255),
                    Double = i,
                    Int = i,
                    Decimal = i
                };
                res.Add(sub);
            }
            return res;
        }
    }
}
