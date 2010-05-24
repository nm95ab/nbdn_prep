using System;
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

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
            foreach (var movie in movies)
            {
                if (movie.production_studio != ProductionStudio.Pixar) yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            foreach (var movie in movies)
            {
                if (movie.date_published > new DateTime(year, 1, 1)) yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            foreach (var movie in movies)
            {
                if (movie.date_published >= new DateTime(startingYear, 1, 1) &&
                    movie.date_published <= new DateTime(endingYear, 12, 31)) yield return movie;
            }
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            foreach (var movie in movies)
            {
                if (movie.genre == Genre.kids) yield return movie;
            }
        }

        public IEnumerable<Movie> all_action_movies()
        {
            foreach (var movie in movies)
            {
                if (movie.genre == Genre.action) yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            foreach (var movie in movies)
            {
                if (movie.production_studio == ProductionStudio.Pixar) yield return movie;
            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            foreach (var movie in movies)
            {
                if (movie.production_studio == ProductionStudio.Pixar ||
                    movie.production_studio == ProductionStudio.Disney) yield return movie;
            }
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