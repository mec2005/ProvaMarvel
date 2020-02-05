using Marvel.Api.Domain.Models.Lists;
using Marvel.Api.Domain.Models.Summaries;

namespace Marvel.Api.Domain.Models.Entities
{      
    public class Story
    {
        #region Properties
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ResourceURI { get; set; }

        public string Type { get; set; }

        public string Modified { get; set; }

        public Thumbnail Thumbnail { get; set; }

        public ComicList Comics { get; set; }

        public SeriesList Series { get; set; }

        public EventList Events { get; set; }

        public CharacterList Characters { get; set; }

        public CreatorList Creators { get; set; }

        public StorySummary OriginalIssue { get; set; }
        #endregion
    }
}
