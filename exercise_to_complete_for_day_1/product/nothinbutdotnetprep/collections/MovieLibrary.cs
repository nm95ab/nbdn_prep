using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetprep.utility.extensions;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            return movies.one_at_a_time();
        }

        public void add(Movie movie)
        {
            if (movies.Contains(movie)) return;

            movies.Add(movie);
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get
            {
                var comparer = new MovieComparer();
                comparer.ComparisonType = ComparisonType.Title;
                ((List<Movie>) movies).Sort(comparer);
                return movies;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get
            {
                var comparer = new MovieComparer();
                comparer.ComparisonType = ComparisonType.Title;
                ((List<Movie>) movies).Sort(comparer);
                return movies.Reverse();
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            var comparer = new MovieComparer();
            comparer.ComparisonType = ComparisonType.RatingDatePublished;
            ((List<Movie>) movies).Sort(comparer);
            return movies;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            var comparer = new MovieComparer();
            comparer.ComparisonType = ComparisonType.DatePublished;
            ((List<Movie>) movies).Sort(comparer);
            return movies.Reverse();
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            var comparer = new MovieComparer();
            comparer.ComparisonType = ComparisonType.DatePublished;
            ((List<Movie>) movies).Sort(comparer);
            return movies;
        }
    }
}