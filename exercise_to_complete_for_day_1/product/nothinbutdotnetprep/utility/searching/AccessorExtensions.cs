using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.utility.searching
{
    public static class AccessorExtensions
    {
        public static Criteria<Movie> equal_to(this StudioAccessor accessor,ProductionStudio studio)
        {
            return new PredicateCriteria<Movie>(movie => accessor(movie) == studio); 
        }
    }
}