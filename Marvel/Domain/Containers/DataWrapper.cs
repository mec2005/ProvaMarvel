using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marvel.Domain.Containers
{
    public class DataWrapper<T> where T : class, new()
    {
        public string Code { get; set; }
        public string Status { get; set; }
        public string Copyright { get; set; }
        public string AttributionText { get; set; }
        public string AttributionHtml { get; set; }
        public DataContainer<T> Data { get; set; }
        public string Etag { get; set; }
    }
}
