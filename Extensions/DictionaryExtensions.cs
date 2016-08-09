using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class DictionaryExtensions
    {
        public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> mapping, TKey key, TValue value,
            IComparer<TKey> compare)
        {
            if (mapping.ContainsKey(key, compare))
            {
                mapping[key] = value;
            }
            else
            {
                mapping.Add(key, value);
            }
        }

        public static bool ContainsKey<TKey, TValue>(this IDictionary<TKey, TValue> mapping, TKey key,
            IComparer<TKey> compare)
        {
            if (mapping.Keys.Any(c => compare.Compare(c, key) == 0))
            {
                return true;
            }
            return false;
        }

        public static TValue GetValue<TKey, TValue>(this Dictionary<TKey,
            TValue> dictionary, TKey key,
            IComparer<TKey> compare)
        {
            var result = default(TValue);
            var item = dictionary.Keys.FirstOrDefault(c => compare.Compare(c, key) == 0);
            if (item != null)
            {
                dictionary.TryGetValue(item, out result);
            }
            return result;
        }
    }
}