using System.Collections.Generic;
using Marvel.Api.Domain.Models.Summaries;

namespace Marvel.Api.Domain.Models.Lists
{
    public class CreatorList
    {
        public string Available { get; set; }
        public string Returned { get; set; }
        public string CollectionURI { get; set; }
        public List<CreatorSummary> Items { get; set; }    
    }
}
