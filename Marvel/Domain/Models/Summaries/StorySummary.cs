using System;

namespace Marvel.Api.Domain.Models.Summaries
{
    public class StorySummary
    {
        public Guid Id { get; set; }
        public string ResourceURI { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
