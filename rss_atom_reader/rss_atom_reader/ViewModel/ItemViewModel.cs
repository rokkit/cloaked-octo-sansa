using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows;

namespace rss_atom_reader.ViewModel
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Item> items = new ObservableCollection<Item>();
        public ObservableCollection<Item> Items
        { get { return items; } }
        private String link;
        public String Link
        {
            get { return link; }
            set
            {
                link = value;
                OnPropertyChanged("Link");
            }
        }
        ReaderFactory factory;
        List<Channel> channels = new List<Channel>();
        public ItemViewModel() { }
        private ICommand mUpdater;
        public ICommand UpdateCommand
        {
            get
            {
                if (mUpdater == null)
                    mUpdater = new GenericCommand(update);
                return mUpdater;
            }
            set
            {
                mUpdater = value;
            }
        }

        private void update(Object message)
        {
            factory = RssReaderFactory.getInstance();
            this.channels.Add(factory.createChannel(link, FeedType.RSS));
            parseChannels();
        }
        private void parseChannels()
        {
            foreach (var channel in this.channels)
            {
                switch (channel.FeedType)
                {
                    case FeedType.RSS:
                        var rssItems = factory.createParser().parse(channel);
                        foreach (var item in rssItems)
                        {
                            Items.Add(item);
                        }
                        break;
                    case FeedType.Atom:
                        break;
                    default:
                        break;
                }
            }
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
    public class GenericCommand : ICommand
    {
        Action<object> _execute = null;

        public GenericCommand(Action<object> execute)
        {
            _execute = execute;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            if (_execute != null)
                _execute(parameter);
        }
    
    }
}
