using nothinbutdotnetprep.utility.searching;

namespace nothinbutdotnetprep.collections
{
    public class IsInGenre: Criteria<Movie>
    {
        Genre genre;

        public IsInGenre(Genre genre)
        {
            this.genre = genre;
        }

        public bool is_satisfied_by(Movie movie)
        {
            return movie.genre == genre;
        }
    }
}