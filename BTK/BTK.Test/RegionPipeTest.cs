using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace BTK.Test
{
    [TestClass]
    public class RegionPipeTest
    {
        [TestMethod]
        public void Returns_Null_When_Empty()
        {
            RegionPipe target = new RegionPipe();
            object result = target.Run(new object());
            Assert.IsNull(result, "The RegionPipe is running even when there is no regions in it.");
        }

        [TestMethod]
        public void Runs_When_Not_Empty()
        {
            Region region = new Region((object obj) => 
            {
                return obj;
            });
            RegionPipe target = new RegionPipe();

            target.Add(region);

            object result = target.Run("Result");

            Assert.AreEqual(result, "Result", "The RegionPipe Run method does not returns the correct value");
        }

        [TestMethod]
        public void Return_Value_Is_Different_Object_Than_Input()
        {
            Region region = new Region((object obj) =>
            {
                return obj;
            });
            RegionPipe target = new RegionPipe();

            target.Add(region);

            object inputObj = new object();

            object result = target.Run(inputObj);

            Assert.AreNotSame(result, inputObj, "The RegionPipe Run method returned the same object(reference) as the input");
        }

        [TestMethod]
        public void Runs_Regions_In_Correct_Order()
        {
            Region region1 = new Region((object obj) =>
            {
                string str = obj as string;
                return str + "region1_";
            });
            Region region2 = new Region((object obj) =>
            {
                string str = obj as string;
                return str + "region2";
            });

            List<IRegion> regions = new List<IRegion>() { region1, region2};

            RegionPipe target = new RegionPipe(regions);

            object result = target.Run(string.Empty);

            Assert.AreEqual(result, "region1_region2");
        }
    }
}
