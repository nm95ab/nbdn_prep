using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class Movie : IEquatable<Movie>
    {
        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public int rating { get; set; }
        public DateTime date_published { get; set; }

        Dictionary<ProductionStudio, int> studioRankings = new Dictionary<ProductionStudio, int>
        {
            {ProductionStudio.MGM, 1},
            {ProductionStudio.Pixar, 2},
            {ProductionStudio.Dreamworks, 3},
            {ProductionStudio.Universal, 4},
            {ProductionStudio.Disney, 5}
        };

        public int CompareTo(Movie other, ComparisonType whichComparison)
        {
            switch (whichComparison)
            {
                case ComparisonType.DatePublished:
                    return this.date_published.CompareTo(other.date_published);
                case ComparisonType.StudioRating:
                    return this.rating.CompareTo(other.rating);
                case ComparisonType.RatingDatePublished:
                    if (studioRankings[this.production_studio].CompareTo(studioRankings[other.production_studio]) != 0)
                        return studioRankings[this.production_studio].CompareTo(studioRankings[other.production_studio]);
                    return this.date_published.CompareTo(other.date_published);
                case ComparisonType.Title:
                    return this.title.CompareTo(other.title);
                default:
                    return 0;
            }
        }

        public override int GetHashCode()
        {
            return title.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Movie);
        }

        public bool Equals(Movie other)
        {
            if (other == null) return false;

            return ReferenceEquals(this, other) || this.title == other.title;
        }
    }




    public class MovieComparer : IComparer<Movie>
    {
        public ComparisonType ComparisonType { get; set; }

        public int Compare(Movie x, Movie y)
        {
            return x.CompareTo(y, ComparisonType);
        }
    }

    public enum ComparisonType
    {
        DatePublished,
        StudioRating,
        RatingDatePublished,
        Title
    }
}