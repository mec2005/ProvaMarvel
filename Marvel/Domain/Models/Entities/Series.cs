﻿using System.Collections.Generic;
using Marvel.Api.Domain.Models.Lists;
using Marvel.Api.Domain.Models.Summaries;

namespace Marvel.Api.Domain.Models.Entities
{
    public class Series
    {
        #region Properties
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ResourceURI { get; set; }

        public List<Url> Urls { get; set; }

        public string StartYear { get; set; }

        public string EndYear { get; set; }

        public string Rating { get; set; }

        public string Modified { get; set; }

        public Thumbnail Thumbnail { get; set; }

        public ComicList Comics { get; set; }

        public StoryList Stories { get; set; }

        public EventList Events { get; set; }

        public CharacterList Characters { get; set; }

        public CreatorList Creators { get; set; }

        public SeriesSummary Next { get; set; }

        public SeriesSummary Previous { get; set; }
        #endregion
    }    
}
