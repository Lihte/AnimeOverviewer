using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Animelist_v0._1
{
    public class EpisodeList : ICollection<Episode>
    {
        private class EpisodeEnumerator : IEnumerator<Episode>
        {
            private EpisodeList _episodeList;
            private int curIndex;
            private Episode curEpisode;

            public EpisodeEnumerator(EpisodeList episodeList)
            {
                _episodeList = episodeList;
                curIndex = -1;
                curEpisode = default(Episode);
            }

            public bool MoveNext()
            {
                // Avoids going beyond th end of the collection.
                if (++curIndex >= _episodeList.Count)
                {
                    return false;
                }
                else
                {
                    // Set current episode to next item in collection.
                    curEpisode = _episodeList[curIndex];
                }
                return true;
            }

            public void Reset() { curIndex = -1; }

            void IDisposable.Dispose() { }

            public Episode Current
            {
                get { return curEpisode; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }

        public IEnumerator<Episode> GetEnumerator()
        {
            return new EpisodeEnumerator(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new EpisodeEnumerator(this);
        }
        
        // The inner collection to store objects.
        private List<Episode> innerCol;
        private List<string> buffer;

        // XML List of anime 
        XDocument doc = XDocument.Load(@"C:\Users\Master\Documents\GitHub\anime-lists\anime-list.xml");

        // For IsReadOnly
        private bool isRO = false;

        public EpisodeList(List<string> dir)
        {
            innerCol = new List<Episode>();
            buffer = new List<string>();

            InitializeList(dir);
        }

        // Adds an index to the collection.
        public Episode this[int index]
        {
            get { return (Episode)innerCol[index]; }
            set { innerCol[index] = value; }
        }

        // Interface methods
        public void Add(Episode item)
        {
            innerCol.Add(item);
        }

        public void Clear()
        {
            innerCol.Clear();
        }

        public bool Contains(Episode item)
        {
            bool found = false;

            foreach (Episode ep in innerCol)
            {
                if (ep.Equals(item))
                {
                    found = true;
                }
            }

            return found;
        }

        public void CopyTo(Episode[] array, int arrayIndex)
        {
            for (int i = 0; i < innerCol.Count; i++)
            {
                array[i] = (Episode)innerCol[i];
            }
        }

        public int Count
        {
            get
            {
                return innerCol.Count;
            }
        }

        public bool IsReadOnly
        {
            get { return isRO; }
        }

        public bool Remove(Episode item)
        {
            bool result = false;

            // Iterate the inner collection to
            // find the box to be removed.
            for (int i = 0; i < innerCol.Count; i++)
            {
                Episode curEpisode = (Episode)innerCol[i];

                if (item.Equals(curEpisode))
                {
                    innerCol.RemoveAt(i);
                    result = true;
                    break;
                }
            }
            return result;
        }

        // Public methods
        public void Add(string filename, string filepath)
        {
            Episode newEpisode = ProcessEpisode(filename, filepath);
            if(newEpisode.Title != "")
                Add(newEpisode);
        }
        
        public void InitializeList(List<string> dir)
        {
            try
            {
                for (int i = 0; i < dir.Count; i++)
                {
                    foreach (string file in Directory.GetFiles(dir[i]))
                    {
                        if(!buffer.Contains(file))
                            Add(Path.GetFileNameWithoutExtension(file), Path.GetFullPath(file));

                        // Make sure no duplicate values gets added by using a buffer list to store filenames.
                        buffer.Add(file);
                    }
                }
            }
            catch (Exception ex)
            {
                Exception ep = ex.InnerException;
            }
        }

        // Private methods

        // This method doesn't work and needs some serious design contemplation
        private Episode ProcessEpisode(string filename, string filepath)
        {
            string title = "";
            string subgroup = "";
            string resolution = "";
            string episodeNr = "";

            string[] splitSeperators = new string[] { "[", "]", "(", ")", "-" };
            string[] temp1 = filename.Split(splitSeperators, StringSplitOptions.RemoveEmptyEntries);

            string[] array;
            
            if (temp1.Length >= 2)
            {
                var name = from anime in doc.Root.Elements("anime")
                           where String.Equals(anime.Element("name").Value, temp1[1].Trim(), StringComparison.OrdinalIgnoreCase)
                           select anime.Element("name").Value;

                array = name.ToArray();

                if (array.Length > 0)
                    title = temp1[1].Trim();
            }

            /*var name = (from anime in doc.Root.Elements("anime")
                       where (filename.IndexOf(anime.Element("name").Value) > -1)
                       select anime.Element("name").Value);*/

            /*List<string> temp = new List<string>();
            
            foreach(string anime in list)
            {
                if(anime.Contains(filename.Substring(filename.IndexOf(anime, anime.Length))))
                {
                    temp.Add(anime);
                }
            }*/

                       /*anime.Element("name").Value.Contains(filename.Substring(Math.Max(filename.IndexOf(anime.Element("name").Value), anime.Element("name").Value.Length)))
                       select anime.Element("name").Value);*/
            try
            {
                if (title != "")
                {
                    subgroup = temp1[0].Trim();
                    resolution = temp1[3].Trim();
                    episodeNr = temp1[2].Trim();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(temp1[2], ex.InnerException);
            }
            
            /*if (temp.Length >= 4)
            {
                title = temp[1].Trim();
                subgroup = temp[0].Trim();
                resolution = temp[3].Trim();
                episodeNr = Int32.Parse(temp[2].Trim());
                return new Episode(filename, filepath, title, subgroup, episodeNr) { };
            }
            else
                return new Episode("", "", "", "", -1);*/

            // Unfinished method, split string into parts and create episode
            return new Episode(filename, filepath, title, subgroup, resolution, episodeNr) { };
        }     
    }
}
