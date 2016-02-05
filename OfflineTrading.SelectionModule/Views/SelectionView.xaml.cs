﻿using Internovus.Wpf.Training.OfflineTrading.Configuration;
using Internovus.Wpf.Training.OfflineTrading.SelectionModule.ViewModels;
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

namespace Internovus.Wpf.Training.OfflineTrading.SelectionModule.Views
{
    /// <summary>
    /// Interaction logic for SelectionView.xaml
    /// </summary>
    public partial class SelectionView : UserControl
    {
        public SelectionView(IEnumerable<Symbol> symbols)
        {
            InitializeComponent();

            DataContext = symbols.Select(s => new SymbolViewModel(s));
        }
    }
}
