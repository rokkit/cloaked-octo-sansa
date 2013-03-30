using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rss_atom_reader
{
    interface ReaderFactory
    {
        Channel createChannel(String link, FeedType ft);
        Item createItem();
        Parser createParser();
    }
}
