﻿using System.Collections.Generic;
using Marvel.Api.Domain.Models.Lists;

namespace Marvel.Api.Domain.Models.Entities
{    
    public class Creator
    {
        #region Properties
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Suffix { get; set; }

        public string FullName { get; set; }

        public string Modified { get; set; }

        public string ResourceURI { get; set; }

        public List<Url> Urls { get; set; }

        public Thumbnail Thumbnail { get; set; }

        public SeriesList Series { get; set; }

        public StoryList Stories { get; set; }

        public ComicList Comics { get; set; }

        public EventList Events { get; set; }
        #endregion
    }
}
