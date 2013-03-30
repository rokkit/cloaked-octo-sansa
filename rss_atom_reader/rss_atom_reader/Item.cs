using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rss_atom_reader
{
    public abstract class Item
    {
        public String Title { get; set; }
        public String Link { get; set; }
    }
}
