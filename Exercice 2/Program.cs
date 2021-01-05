using System;
using System.Collections.Generic;

namespace Exercice_2
{
    class Program
    {
        static void Test_Case1(){
            static IList<KeyValuePair<string, int>> MapFromMem(string key, string value) { 
                List<KeyValuePair<string, int>> result = new List<KeyValuePair<string, int>>(); 
                foreach (var word in value.Split(' ')) { 
                    result.Add(new KeyValuePair<string, int>(word, 1)); 
                } 
                return result; 
            }

            static IEnumerable<int> Reduce(string key, IEnumerable<int> values) { 
                int sum = 0; 
                foreach (int value in values) { 
                    sum += value; 
                } 
                return new int[1] { sum }; 
            }

            MapReduceProgram<string, string, string, int, int> master = new MapReduceProgram<string, string, string, int, int>(MapFromMem, Reduce); 
            var result = master.Execute(InputData).ToDictionary(key => key.Key, v => v.Value);
        }
        

        static void Main(string[] args)
        {
            Test_Case1();
        }
    }
}
