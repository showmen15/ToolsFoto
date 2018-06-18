using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FroniusSymo.FroniusSolar
{
    public class DuplicateDictionary<TKey, TValue> : Dictionary<TKey, List<TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>
    {
        public new IEnumerable<KeyValuePair<TKey, TValue>> this[TKey key]
        {
            get
            {
                List<TValue> values;
                if (!TryGetValue(key, out values))
                {
                    return Enumerable.Empty<KeyValuePair<TKey, TValue>>();
                }

                return values.Select(v => new KeyValuePair<TKey, TValue>(key, v));
            }
            set
            {
                foreach (var _value in value.Select(kvp => kvp.Value))
                {
                    Add(key, _value);
                }
            }
        }



        public void Add(TKey key, TValue value)
        {
            List<TValue> values;
            if (!TryGetValue(key, out values))
            {
                values = new List<TValue>();
                Add(key, values);
            }
            values.Add(value);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (var item in ((Dictionary<TKey, List<TValue>>)this))
            {
                foreach (var value in item.Value)
                {
                    yield return new KeyValuePair<TKey, TValue>(item.Key, value);
                }
            }
        }
    }
}
