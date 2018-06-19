using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FroniusSymo.FroniusSolar
{
    [Serializable]
    public class MyJsonDictionary<K, V> : ISerializable
    {
        List<KeyValuePair<K, V>> dict = new List<KeyValuePair<K, V>>();

        public MyJsonDictionary() { }

        protected MyJsonDictionary(SerializationInfo info, StreamingContext context)
        {
            SerializationInfoEnumerator date = info.GetEnumerator();

            while (date.MoveNext())
            {
                K key = (K)Convert.ChangeType(date.Current.Name, typeof(K));
                V value = (V)Convert.ChangeType(date.Current.Value, typeof(V));

                dict.Add(new KeyValuePair<K, V>(key, value));
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {          
            foreach (KeyValuePair<K, V> key in dict)
            {
                info.AddValue(key.Key.ToString(), key.Value);
            }
        }

        public void Add(K key, V value)
        {
            dict.Add(new KeyValuePair<K, V>(key, value));
        }
    }
}
