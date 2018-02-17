using System.Collections.Generic;

namespace BTK
{
    public class RegionPipe
    {
        private List<IRegion> _regions;

        public RegionPipe()
        {
            _regions = new List<IRegion>();
        }

        public RegionPipe(List<IRegion> regions)
        {
            _regions = regions;
        }

        public void Add(IRegion region)
        {
            _regions.Add(region);
        }

        public void Remove(IRegion region)
        {
            _regions.Remove(region);
        }

        public object Run(object input)
        {
            if (_regions.Count < 1)
            {
                return null;
            }
            object result = input;
            foreach (IRegion region in _regions)
            {
                region.Run(result);
                result = region.Result;
            }
            return result;
        }
    }
}
