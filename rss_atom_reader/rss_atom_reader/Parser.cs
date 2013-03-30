using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rss_atom_reader
{
    class Parser
    {
        ParseStrategy ps;
        public Parser(ParseStrategy strategy)
        {
            this.ps = strategy;
        }
        public IList<Item> parse(Channel c)
        {
            return ps.parse(c);
        }
    }
}
