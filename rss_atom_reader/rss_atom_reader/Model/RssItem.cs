using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rss_atom_reader
{
    public class RssItem : Item
    {

        public String Subtitle { get; set; }
        public String Image { get; set; }
        public String Content { get; set; }
    }
}
