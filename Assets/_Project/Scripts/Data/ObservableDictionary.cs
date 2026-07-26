using System;
using System.Collections.Generic;

namespace _Project.Data
{
    public class ObservableDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public EventHandler<TKey> ItemAdded;
        public EventHandler<TKey> ItemRemoved;

        public ObservableDictionary() : base()
        {
        }

        public new void Add(TKey key, TValue value)
        {
            base.Add(key, value);
            ItemAdded?.Invoke(null, key);
        }

        public new bool Remove(TKey key)
        {
            var removed = base.Remove(key);
            if (removed) ItemRemoved(null, key);

            return removed;
        }
    }
}
