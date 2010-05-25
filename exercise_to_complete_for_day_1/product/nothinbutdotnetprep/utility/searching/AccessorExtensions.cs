namespace nothinbutdotnetprep.utility.searching
{
    public static class AccessorExtensions
    {
        public static Criteria<ItemToFilter> equal_to<ItemToFilter, PropertyType>(
            this PropertyAccessor<ItemToFilter, PropertyType> accessor,
            PropertyType value)
        {
            return new PredicateCriteria<ItemToFilter>(x => accessor(x).Equals(value));
        }
    }
}