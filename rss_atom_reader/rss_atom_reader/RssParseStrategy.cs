using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace rss_atom_reader
{
    class RssParseStrategy : ParseStrategy
    {
        public IList<Item> parse(Channel channel)
        {
            try
            {
                XDocument doc = XDocument.Load(channel.Link);
                // RSS/Channel/item
                var entries = from item in doc.Root.Descendants().First(i => i.Name.LocalName == "channel").Elements().Where(i => i.Name.LocalName == "item")
                              select new RssItem
                              {

                                  Content = item.Elements().First(i => i.Name.LocalName == "description").Value,
                                  Link = item.Elements().First(i => i.Name.LocalName == "link").Value,
                                 // PublishDate = ParseDate(item.Elements().First(i => i.Name.LocalName == "pubDate").Value),
                                  Title = item.Elements().First(i => i.Name.LocalName == "title").Value
                              };
                IList<Item> result_list = new List<Item>();

                foreach (var entry in entries.ToList()) {
                    result_list.Add(entry);
                }
                return result_list;
            }
            catch
            {
                return new List<Item>();
            }
        }
    }
}
