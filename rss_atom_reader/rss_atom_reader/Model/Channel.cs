using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rss_atom_reader
{
    abstract class Channel : INotifyPropertyChanged
    {
        public String title { get; set; }
        private String link;
        public String Link
        {
            get { return link; }
            set {
                link = value;
                OnPropertyChanged("Link");
            }
        }
        public FeedType FeedType { get; set; }
        protected Channel(String link, FeedType ft) {
            this.link = link;
            this.FeedType = ft;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }

    public enum FeedType
    {
        RSS,
        Atom
    }
}
