using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rss_atom_reader
{
    abstract class Channel
    {
        public String title { get; set; }
        public String link { get; set; }
        public FeedType FeedType { get; set; }
        protected Channel(String link, FeedType ft) {
            this.link = link;
            this.FeedType = ft;
        }

    }

    public enum FeedType
    {
        RSS,
        Atom
    }
}
