﻿using System.Collections.Generic;
using Marvel.Api.Domain.Models.Lists;
using Marvel.Api.Domain.Models.Summaries;

namespace Marvel.Api.Domain.Models.Entities
{
    public class Event
    {
        #region Properties
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ResourceURI { get; set; }

        public List<Url> Urls { get; set; }

        public string Modified { get; set; }

        public string Start { get; set; }

        public string End { get; set; }

        public Thumbnail Thumbnail { get; set; }

        public ComicList Comics { get; set; }
        
        public StoryList Stories { get; set; }

        public SeriesList Series { get; set; }

        public CharacterList Characters { get; set; }

        public CreatorList Creators { get; set; }

        public EventSummary Next { get; set; }

        public EventSummary Previous { get; set; }
        #endregion
    }    
}
