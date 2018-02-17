using System;
using BTK;

namespace Example1.Regions
{
    class V1 : Region
    {
        public V1()
        {
            Name = "V1";

            PreProcessAction = () =>
            {
                Console.WriteLine("Brain Region {0} started", Name);
            };

            ProcessFunction = (object obj) =>
            {
                Console.WriteLine("Brain Region {0} is processing", Name);
                return (obj as string) + "Hello ";
            };

            PostProcessAction = () =>
            {
                Console.WriteLine("Brain Region {0} finished running! Elapsed Time: {1}"
                    + Environment.NewLine, Name, ElapsedTime);
            };
        }
    }
}
