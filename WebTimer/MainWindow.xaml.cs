﻿using System;
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

namespace WebTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WTimer model;

        public MainWindow()
        {
            InitializeComponent();
            model = new WTimer();
            model.CodingMinutes = 25;
            model.SurfingMinutes = 5;
            DataContext = model;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            model.Toggle();
        }
    }
}
