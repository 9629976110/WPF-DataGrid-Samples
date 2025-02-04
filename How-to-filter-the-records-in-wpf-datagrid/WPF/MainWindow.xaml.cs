﻿using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
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

namespace SearchPanel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow :Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
            textbox.TextChanged += Textbox_TextChanged;
        }

        private void Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = (e.Source as TextBox).Text.ToLower();
            this.sfGrid.SearchHelper.AllowFiltering = true;
            this.sfGrid.SearchHelper.Search(text);
        }
    }
}
