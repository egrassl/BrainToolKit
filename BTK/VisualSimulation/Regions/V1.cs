using System;
using System.Collections.Generic;
using System.Text;
using OpenCvSharp;
using OpenCvSharp.XFeatures2D;
using BTK;

namespace VisualSimulation.Regions
{
    class V1 : Region
    {
        public V1()
        {
            ProcessFunction = (object obj) =>
            {
                dynamic images = obj as dynamic;
                var src1 = images.src1;
                var src2 = images.src2;

                var gray1 = new Mat();
                var gray2 = new Mat();

                Cv2.CvtColor(src1, gray1, ColorConversionCodes.BGR2GRAY);
                Cv2.CvtColor(src2, gray2, ColorConversionCodes.BGR2GRAY);

                var surf = SURF.Create(200, 4, 2, true);
                
                // Detect the keypoints and generate their descriptors using SURF
                KeyPoint[] keypoints1, keypoints2;
                var descriptors1 = new MatOfFloat();
                var descriptors2 = new MatOfFloat();
                surf.DetectAndCompute(gray1, null, out keypoints1, descriptors1);
                surf.DetectAndCompute(gray2, null, out keypoints2, descriptors2);
                return new
                {
                    gray1,
                    gray2,
                    descriptors1,
                    descriptors2,
                    keypoints1,
                    keypoints2
                };
            };

            PostProcessAction = () =>
            {
                Console.WriteLine("V1 terminou de processar!! Tempo gasto: {0}" + Environment.NewLine, ElapsedTime);
            };
        }
    }


}
