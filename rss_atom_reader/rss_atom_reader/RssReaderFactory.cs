using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rss_atom_reader
{
    class RssReaderFactory : ReaderFactory 
    {
        private static RssReaderFactory instance;
        private RssReaderFactory() { }
        public static RssReaderFactory getInstance()
        {
            if(instance == null) 
                instance = new RssReaderFactory();

             return instance;
        }
        public Channel createChannel(String link, FeedType ft)
        {
            return new RssChannel(link, ft);
        }

        public Item createItem()
        {
            return new RssItem();
        }

        public Parser createParser()
        {
            return new Parser(new RssParseStrategy());
        }
    }
}
