using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marvel.Domain.Containers
{
    public class DataContainer<T> where T : class, new()
    {
        public string Offset => 0.ToString();
        public string Limit => 0.ToString();
        public string Total => Results.Count().ToString();
        public string Count => Results.Count().ToString();
        public IEnumerable<T> Results { get; set; }
    }
}
