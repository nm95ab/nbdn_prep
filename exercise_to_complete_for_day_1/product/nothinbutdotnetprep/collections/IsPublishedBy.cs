using nothinbutdotnetprep.utility.searching;

namespace nothinbutdotnetprep.collections
{
    public class IsPublishedBy : Criteria<Movie>
    {
        ProductionStudio production_studio;

        public IsPublishedBy(ProductionStudio production_studio)
        {
            this.production_studio = production_studio;
        }

        public bool is_satisfied_by(Movie movie)
        {
            return movie.production_studio == production_studio;
        }
    }
}