﻿using System.Windows;
using ImageViewer.ViewModels;

namespace ImageViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MW_ViewModel();           
        }
      
    }
}
