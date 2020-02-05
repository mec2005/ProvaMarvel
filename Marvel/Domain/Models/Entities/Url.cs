using System;

namespace Marvel.Api.Domain.Models.Entities
{
    public class Url
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string URL { get; set; }
    }
}
