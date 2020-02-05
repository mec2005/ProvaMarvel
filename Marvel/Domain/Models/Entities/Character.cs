using System.Collections.Generic;
using Marvel.Api.Domain.Models.Lists;
using Newtonsoft.Json;

namespace Marvel.Api.Domain.Models.Entities
{
    public class Character
    {
        #region Properties
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        public string Modified { get; set; }

        public string ResourceURI { get; set; }

        public List<Url> Urls { get; set; }

        public Thumbnail Thumbnail { get; set; }

        public ComicList Comics { get; set; }

        public StoryList Stories { get; set; }

        public EventList Events { get; set; }

        public SeriesList Series { get; set; }
        #endregion
    }  
}
