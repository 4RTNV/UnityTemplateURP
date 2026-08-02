using System;
using System.Collections.Generic;

namespace _Project.Data
{
    public class ObservableDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        private EventHandler<TKey> _itemAdded;
        private EventHandler<TKey> _itemRemoved;

        public new void Add(TKey key, TValue value)
        {
            base.Add(key, value);
            _itemAdded?.Invoke(null, key);
        }

        public new bool Remove(TKey key)
        {
            var removed = base.Remove(key);
            if (removed) _itemRemoved(null, key);

            return removed;
        }
    }
}
