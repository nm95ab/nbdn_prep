using nothinbutdotnetprep.collections;

namespace nothinbutdotnetprep.utility.searching
{
    public delegate ProductionStudio StudioAccessor(Movie movie);

    public class Where
    {
        public static StudioAccessor has_a(StudioAccessor accessor)
        {
            return accessor;
        }
    }
}