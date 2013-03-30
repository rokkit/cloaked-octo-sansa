using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rss_atom_reader
{
    interface ParseStrategy
    {
        IList<Item> parse(Channel channel);
    }
}
