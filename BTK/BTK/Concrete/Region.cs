using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BTK
{
    public class Region : IRegion
    {
        private TimeSpan _elapsedTime;

        private object _result;

        public string Name { get; set; }

        public Action PostProcessAction { get; set; }

        public Action PreProcessAction { get; set; }
        
        public Func<object, object> ProcessFunction { get; set; }


        public TimeSpan ElapsedTime
        {
            get
            {
                if (_result == null)
                {
                    throw new InvalidOperationException("Cannot return elapsed time before running the ProcessFunction delegate!");
                }
                return _elapsedTime;
            }
        }
        
        public object Result
        {
            get
            {
                if (_result == null)
                {
                    throw new InvalidOperationException("Cannot return result before running the ProcessFunction delegate!");
                }
                return _result;
            }
        }

        public void Run(object input)
        {
            if (ProcessFunction == null)
            {
                throw new NotImplementedException("The ProcessFunction delegate must be implemented!");
            }
            PreProcessAction?.Invoke();
            DateTime initialTime = DateTime.Now;
            _result = ProcessFunction(input);
            DateTime endingTime = DateTime.Now;
            _elapsedTime = endingTime - initialTime;
            PostProcessAction?.Invoke();
        }

        public Region(Func<object, object> processFunction = null, Action preProcessAction = null, Action postProcessAction = null)
        {
            _elapsedTime = TimeSpan.Zero;
            PreProcessAction = preProcessAction;
            ProcessFunction = processFunction;
            PostProcessAction = postProcessAction;
        }
    }
}
