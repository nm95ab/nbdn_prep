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
            return all_movies_matching(is_not_published_by_pixar);
        }

        public static Predicate<Movie> is_not_published_by_pixar
        {
            get { return x => x.production_studio != ProductionStudio.Pixar; }
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            all_movies_matching(is_published_after(year));
        }

        Predicate<Movie> is_published_after(int year)
        {
            return movie => movie.date_published > new DateTime(year, 1, 1);
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            all_movies_matching(movie => movie.date_published >= new DateTime(startingYear, 1, 1) &&
                movie.date_published <= new DateTime(endingYear, 12, 31));
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            all_movies_matching(is_a_kid_movie());
        }

        Predicate<Movie> is_a_kid_movie()
        {
            return movie => movie.genre == Genre.kids;
        }

        public IEnumerable<Movie> all_action_movies()
        {
            all_movies_matching(is_an_action_movie());
        }

        Predicate<Movie> is_in_genre(Genre genre)
        {
                 
        }

        Predicate<Movie> is_an_action_movie()
        {
            return movie => movie.genre == Genre.action;
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            all_movies_matching(x => x.production_studio == ProductionStudio.Pixar);
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            all_movies_matching(movie => movie.production_studio == ProductionStudio.Pixar ||
                movie.production_studio == ProductionStudio.Disney);
        }

        IEnumerable<Movie> all_movies_matching(Predicate<Movie> criteria)
        {
            return movies.all_items_matching(criteria);
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