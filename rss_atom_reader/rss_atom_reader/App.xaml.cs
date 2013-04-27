﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using rss_atom_reader.ViewModel;

namespace rss_atom_reader
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            rss_atom_reader.MainWindow window = new MainWindow();
            ItemViewModel VM = new ItemViewModel();
            window.DataContext = VM;
            window.Show();
        }
    }
}
