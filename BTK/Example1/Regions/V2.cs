using System;
using BTK;

namespace Example1.Regions
{
    class V2 : Region
    {
        public V2()
        {
            Name = "V2";

            PreProcessAction = PrintInitialTime;

            ProcessFunction = ConcatenateString;

            PostProcessAction = PrintEndingTime;
        }

        private void PrintInitialTime()
        {
            Console.WriteLine("Brain Region {0} started", Name);
        }

        private object ConcatenateString(object str)
        {
            Console.WriteLine("Brain Region {0} is processing", Name);
            return (str as string) + "World!";
        }

        private void PrintEndingTime()
        {
            Console.WriteLine("Brain Region {0} finished running! Elapsed Time: {1}"
                    + Environment.NewLine, Name, ElapsedTime);
        }
    }
}
