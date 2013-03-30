using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace rss_atom_reader
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ReaderFactory factory;
        List<Channel> channels;
        ObservableCollection<Item> items =  new ObservableCollection<Item>();
        public ObservableCollection<Item> Items
        { get { return items; } }
        public MainWindow()
        {
            DataContext = this;
            channels = new List<Channel>();
            //link_box.Text = "http://www.ft.com/rss/home/uk";
            ReaderFactory factory = RssReaderFactory.getInstance();
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.factory = RssReaderFactory.getInstance();
            channels.Add(factory.createChannel(link_box.Text, FeedType.RSS));
            parseChannels();
        }

        private void parseChannels() {
            foreach (var channel in this.channels)
            {
                switch (channel.FeedType)
                {
                    case FeedType.RSS:
                        var rssItems = factory.createParser().parse(channel);
                        foreach (var item in rssItems)
                        {
                            items.Add(item);
                        }
                        break;
                    case FeedType.Atom:
                        break;
                    default:
                        break;
                }
            }
        }

        private void Hyperlink_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("ok");
            System.Diagnostics.Process.Start("http://www.wikipedia.com");
        }
    }
}
