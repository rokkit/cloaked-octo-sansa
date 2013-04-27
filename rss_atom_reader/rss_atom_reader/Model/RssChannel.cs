using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rss_atom_reader
{
    class RssChannel:Channel
    {
        public RssChannel(String link, FeedType ft) : base(link, ft) { }
    }
}
