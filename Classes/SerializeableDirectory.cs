using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animelist_v0._1
{
    public class SerializeableDirectory : SerializableKeyValuePair<string, bool>
    {
        public string[] Subdirectories
        { get; set; }

        // Private default constructor for no empty instance creation
        private SerializeableDirectory() { }

        public SerializeableDirectory(string key, bool value) : base(key, value) { }

        public SerializeableDirectory(string key, bool value, string[] sub)
            : base(key, value)
        {
            this.Subdirectories = sub;
        }

    }
}

