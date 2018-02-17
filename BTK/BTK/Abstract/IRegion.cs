using System;

namespace BTK
{
    public interface IRegion
    {
        string Name { get; set; }

        Action PostProcessAction { get; set; }

        Action PreProcessAction { get; set; }

        Func<object, object> ProcessFunction { get; set; }

        TimeSpan ElapsedTime { get; }

        object Result { get; }

        void Run(object input);
    }
}
