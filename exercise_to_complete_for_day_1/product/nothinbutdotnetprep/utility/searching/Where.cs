namespace nothinbutdotnetprep.utility.searching
{
    public delegate PropertyType PropertyAccessor<ItemToFilter,PropertyType>(ItemToFilter item);

    public class Where<ItemToFilter>
    {

       public static CriteriaFactory<ItemToFilter,PropertyType> has_a<PropertyType>(
            PropertyAccessor<ItemToFilter,PropertyType> accessor)
        {
          
            return new CriteriaFactory<ItemToFilter, PropertyType>(accessor);
        }

        
      }

    public class CriteriaFactory<ItemToFilter, PropertyType>
    {
        public PropertyAccessor<ItemToFilter, PropertyType> accessor;

        public CriteriaFactory(PropertyAccessor<ItemToFilter, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public PredicateCriteria<ItemToFilter> equal_to(PropertyType propertyValue)
        {
            return new PredicateCriteria<ItemToFilter>(x => accessor(x).Equals(propertyValue));
        }

        public PredicateCriteria<ItemToFilter> not_equal_to(PropertyType propertyValue)
        {
            return new PredicateCriteria<ItemToFilter>(x => !accessor(x).Equals(propertyValue));
        }
        /*
        public PredicateCriteria<ItemToFilter> equal_to_any(PropertyType[] propertyValues)
        {
            return new PredicateCriteria<ItemToFilter>(x =>
            {
                foreach (var propertyValue in propertyValues)
                {
                    if (accessor(x).Equals(propertyValue))
                        break;
                }
                
            });
        }
         * */
    }
}