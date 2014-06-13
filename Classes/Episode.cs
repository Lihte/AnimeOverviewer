using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animelist_v0._1
{
    public class Episode : IEquatable<Episode>
    {
        public string Filename { get; set; }
        public string Filepath { get; set; }
        public string Title { get; set; }
        public string Subgroup { get; set; }
        public string Resolution { get; set; }
        public string Number { get; set; }

        private Episode() { }

        public Episode(string filename, string filepath, string title, string sub, string res, string number)
        {
            this.Filename = filename;
            this.Filepath = filepath;
            this.Title = title;
            this.Subgroup = sub;
            this.Resolution = res;
            this.Number = number;
        }

        public bool Equals(Episode item)
        {
            if (this.Filename == item.Filename)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*public bool Equals(Episode obj)
        {
            return base.Equals(obj);
        }*/

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
