using System;

namespace nothinbutdotnetprep.utility.searching
{
    public class PredicateCriteria<T> : Criteria<T>
    {
        Predicate<T> actual_criteria;

        public PredicateCriteria(Predicate<T> actual_criteria)
        {
            this.actual_criteria = actual_criteria;
        }

        public bool is_satisfied_by(T item)
        {
            return actual_criteria(item);
        }
    }
}