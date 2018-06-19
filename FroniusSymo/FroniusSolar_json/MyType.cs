using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FroniusSymo.FroniusSolar
{
    [Serializable]
    public class MyType<TKey, TValue> : ISerializable
    {
        List<TKey> tkey = new List<TKey>();
        List<TValue> tvalue = new List<TValue>();


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            for (int i = 0; i < tkey.Count; i++)
                info.AddValue(tkey[i].ToString(), tvalue[i].ToString());
        }

        public void Add(TKey key, TValue value)
        {
            tkey.Add(key);
            tvalue.Add(value);
        }
    }
}