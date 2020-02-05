﻿using System;

namespace Marvel.Api.Domain.Models.Summaries
{
    public class CharacterSummary
    {
        public Guid Id { get; set; }
        public string ResourceURI { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
