using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.utility.searching
{
    public delegate PropertyType  PropertyAccessor<ItemToFilter,PropertyType>(ItemToFilter item);

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

        public Criteria<ItemToFilter> equal_to(PropertyType propertyValue)
        {
            return new PredicateCriteria<ItemToFilter>(x => accessor(x).Equals(propertyValue));
        }

        public Criteria<ItemToFilter> not_equal_to(PropertyType propertyValue)
        {
            return new NotCriteria<ItemToFilter>(equal_to(propertyValue));
        }

        public Criteria<ItemToFilter> after(int propertyValue)
        {

            return new PredicateCriteria<ItemToFilter>(x => (DateTime.Parse(accessor(x).ToString())).Year > propertyValue);
        }

        public Criteria<ItemToFilter> between(int start,int end)
        {
            return new PredicateCriteria<ItemToFilter>(x => (DateTime.Parse(accessor(x).ToString())).Year >= start && (DateTime.Parse(accessor(x).ToString())).Year < end);
        }

        public Criteria<ItemToFilter> equal_to_any(params PropertyType[] propertyValues)
        {
            return new PredicateCriteria<ItemToFilter>(x =>
                                                           {
                                                               return
                                                                   new List<PropertyType>(propertyValues).Contains(
                                                                       accessor(x));

                                                           });
            
           
        }
   
    }
}