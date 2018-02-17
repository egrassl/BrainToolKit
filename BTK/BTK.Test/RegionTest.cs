using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BTK.Test
{
    [TestClass]
    public class RegionTest
    {
        private string _resultString = "Test result";

        private string _preAndPostActResult = string.Empty;

        private string _preActString = "PreActionExecuted";

        private bool _preActExecuted = false;

        private string _postActString = "PostActionExecuted";

        private bool _postActExecuted = false;

        public object ProcessFunc(object str)
        {
            return str;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), AllowDerivedTypes = false)]
        public void Cannot_Get_Result_Before_Processing()
        {
            IRegion target = new Region(ProcessFunc);
            object result = target.Result;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), AllowDerivedTypes = false)]
        public void Cannot_Get_Elapsed_Time_Before_Processing()
        {
            IRegion target = new Region(ProcessFunc);
            TimeSpan elapsedTime = target.ElapsedTime;
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException), AllowDerivedTypes = false)]
        public void Cannot_Run_When_Process_Function_Is_Not_Implemented()
        {
            IRegion target = new Region();
            target.Run(_resultString);
        }

        [TestMethod]
        public void Can_Get_Result_After_Processing()
        {
            IRegion target = new Region(ProcessFunc);
            target.Run(_resultString);
            Assert.AreEqual(_resultString, target.Result, "ProcessFunction result is not correct!");
        }

        [TestMethod]
        public void Can_Run_Pre_And_Post_Process_Actions()
        {
            Action preProcessAct = () =>
            {
                _preAndPostActResult += _preActString;
                _preActExecuted = true;
            };

            Action postProcessAct = () =>
            {
                _preAndPostActResult += _postActString;
                _postActExecuted = true;
            };
            IRegion target = new Region(ProcessFunc, preProcessAct, postProcessAct);

            target.Run(_resultString);

            Assert.AreEqual(_preActExecuted, true, "PreProcessAction was not executed.");
            Assert.AreEqual(_postActExecuted, true, "PostProcessAction was not executed.");
            Assert.AreEqual(_preAndPostActResult, _preActString + _postActString,
                "The Pre And Post Processing delegates are not being executed in the right order.");
        }
    }
}
