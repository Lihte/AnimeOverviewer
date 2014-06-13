using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Animelist_v0._1
{
    [Serializable]
    [XmlType(TypeName = "SerializableKeyValuePair")]
    public class SerializableKeyValuePair<K, V>
    {
        public K Key
        { get; set; }

        public V Value
        { get; set; }

        private SerializableKeyValuePair() { }

        public SerializableKeyValuePair(K key, V value)
        {
            this.Key = key;
            this.Value = value;
        }

    }
}
