﻿using System;
using System.Collections.Generic;
using Marvel.Api.Domain.Models.Summaries;

namespace Marvel.Api.Domain.Models.Lists
{
    public class SeriesList
    {
        public Guid Id { get; set; }
        public string Available { get; set; }
        public string Returned { get; set; }
        public string CollectionURI { get; set; }
        public List<SeriesSummary> Items { get; set; }
    }
}
