using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.XFeatures2D;
using BTK;

namespace VisualSimulation.Regions
{
    class V2 : Region
    {
        public V2()
        {
            ProcessFunction = (object obj) =>
            {
                dynamic prt = obj as dynamic;
                var descriptors1 = prt.descriptors1;
                var descriptors2 = prt.descriptors2;
                var keypoints1 = prt.keypoints1;
                var keypoints2 = prt.keypoints2;
                Mat gray1 = prt.gray1;
                Mat gray2 = prt.gray2;
                // Match descriptor vectors 
                var bfMatcher = new BFMatcher(NormTypes.L2, false);
                var flannMatcher = new FlannBasedMatcher();
                DMatch[] bfMatches = bfMatcher.Match(descriptors1, descriptors2);
                DMatch[] flannMatches = flannMatcher.Match(descriptors1, descriptors2);

                // Draw matches
                var bfView = new Mat();
                Cv2.DrawMatches(gray1, keypoints1, gray2, keypoints2, bfMatches, bfView);
                var flannView = new Mat();
                Cv2.DrawMatches(gray1, keypoints1, gray2, keypoints2, flannMatches, flannView);
                return new { bfView, flannView };
            };

            PostProcessAction = () =>
            {
                Console.WriteLine("V2 terminou de processar!! Tempo gasto: {0}" + Environment.NewLine, ElapsedTime);
            };
        }
    }
}
