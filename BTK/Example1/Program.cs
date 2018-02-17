using System;
using System.Diagnostics;
using System.Collections.Generic;
using BTK;
using Example1.Regions;

namespace Example1
{
    class Program
    {
        static void Main(string[] args)
        {
            V1 v1 = new V1();
            V2 v2 = new V2();
            List<IRegion> regions = new List<IRegion>() { v1, v2 };
            RegionPipe pipe = new RegionPipe(regions);
            string result = pipe.Run(string.Empty) as string;

            Console.WriteLine("=========THE PIPE FINISHED RUNNING=========");
            Console.WriteLine("V1 output: \"{0}\", Elapsed Time: {1}", v1.Result, v1.ElapsedTime);
            Console.WriteLine("V2 output: \"{0}\", Elapsed Time: {1}", v2.Result, v2.ElapsedTime);
            Console.WriteLine("Pipe output: \"{0}\"", result);
            Console.ReadLine();
        }
    }
}
