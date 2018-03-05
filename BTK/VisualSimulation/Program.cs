using System;
using OpenCvSharp;
using OpenCvSharp.XFeatures2D;
using VisualSimulation.Regions;
using BTK;
using System.Collections.Generic;

namespace VisualSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            V1 v1 = new V1();
            V2 v2 = new V2();
            List<IRegion> regions = new List<IRegion>() { v1, v2 };
            RegionPipe pipe = new RegionPipe(regions);
            dynamic result = pipe.Run(new
            {
                src1 = new Mat("images/box.png", ImreadModes.Color),
                src2 = new Mat("images/box_in_scene.png", ImreadModes.Color)
            });
            using (new Window("SURF matching (by BFMather)", WindowMode.AutoSize, result.bfView))
            using (new Window("SURF matching (by FlannBasedMatcher)", WindowMode.AutoSize, result.flannView))
            {
                Cv2.WaitKey();
            }
        }
    }
}
