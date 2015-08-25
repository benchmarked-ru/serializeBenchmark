using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using serializeBenchmarks.Serializers;

namespace serializeBenchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var type = typeof(Model);
            var serializers = new Dictionary<string, ISerializer>
            {
                {"Binary", new Binary()},
                {"DataContract", new DataContract(type)},
                {"Json", new Json(type)},
                {"Protobuf", new Protobuf()},
                {"Xml", new Xml(type)},
                {"Jil", new Serializers.Jil()}
           };
            var resultTime = new Dictionary<string, List<long>>();
            var resultMemory = new Dictionary<string, List<long>>();
            foreach (var serializer in serializers.Keys)
            {
                resultTime[serializer] = new List<long>();
                resultMemory[serializer] = new List<long>();
            }

            Tester.Test(serializers);

            var measurer = new Measurer();
            var keyPoints = new List<int> { 10, 20, 50, 100, 200, 500, 1000, 3000, 7000, 10000 };
            
            foreach (var keyPoint in keyPoints)
            {
                Console.WriteLine(keyPoint);
                var timeMeasure = measurer.MeasureTime(serializers, keyPoint);
                var memoryMeasure = measurer.MeasureMemory(serializers, keyPoint);
                foreach (var time in timeMeasure)
                {
                    resultTime[time.Key].Add(time.Value);
                }
                foreach (var memory in memoryMeasure)
                {
                    resultMemory[memory.Key].Add(memory.Value);
                }
            }

            using (var fileTime = new StreamWriter(@"benchmarkTime.txt"))
            using (var fileMemory = new StreamWriter(@"benchmarkMemory.txt"))
            {
                fileTime.WriteLine("\'Количество моделей\' " + string.Join(" ", keyPoints));
                fileMemory.WriteLine("\'Количество подмоделей\' " + string.Join(" ", keyPoints));
                foreach (var serializer in serializers)
                {
                    var timeText = string.Format("\'{0}\' ", serializer.Key) + string.Join(" ", resultTime[serializer.Key]);
                    var memoryText = string.Format("\'{0}\' ", serializer.Key) + string.Join(" ", resultMemory[serializer.Key]);

                    fileTime.WriteLine(timeText);
                    fileMemory.WriteLine(memoryText);
                }
            }

            Console.WriteLine("Benchmark done");
        }
    }
}
