using System;
using System.Collections;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class LazyEnumerable<T> : IEnumerable<T>
    {
        IEnumerable<T> items;

        public LazyEnumerable(IEnumerable<T> items)
        {
            this.items = items;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            Console.Out.WriteLine("I am about to iterate all of the movies");
            foreach (var item in items)
            {
                Console.Out.WriteLine("I am iterating over an item");
                yield return item;
            }
        }
    }
}