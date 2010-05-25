using System;

namespace nothinbutdotnetprep.utility.searching
{
    public delegate PropertyType PropertyAccessor<ItemToFilter, PropertyType>(ItemToFilter item);

    public class Where<ItemToFilter>
    {
        public static CriteriaFactory<ItemToFilter, PropertyType> has_a<PropertyType>(
            Func<ItemToFilter, PropertyType> accessor)
        {
            return new CriteriaFactory<ItemToFilter, PropertyType>(accessor);
        }
    }

    public class CriteriaFactory<ItemToFilter, PropertyType>
    {
        Func<ItemToFilter,PropertyType> accessor;

        public CriteriaFactory(Func<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public Criteria<ItemToFilter> equal_to(PropertyType value)
        {
            return new PredicateCriteria<ItemToFilter>(x => accessor(x).Equals(value));
        }
    }
}