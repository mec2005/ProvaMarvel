using System;

namespace Marvel.Api.Domain.Models.Entities
{
    public class Thumbnail
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
    }
}