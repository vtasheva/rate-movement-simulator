﻿using Internovus.Wpf.Training.OfflineTrading.Common.Configuration;
using Internovus.Wpf.Training.OfflineTrading.SymbolsModule.ViewModels;
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

namespace Internovus.Wpf.Training.OfflineTrading.SymbolsModule.Views
{
    /// <summary>
    /// Interaction logic for TabsView.xaml
    /// </summary>
    public partial class TabsView : UserControl
    {
        public TabsView(IEnumerable<ISymbolViewModel> symbolViewModels)
        {
            InitializeComponent();

            DataContext = symbolViewModels;
        }
    }
}