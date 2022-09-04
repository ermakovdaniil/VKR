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
using System.Windows.Shapes;
using VKR.ViewModel;

namespace VKR
{
    /// <summary>
    /// Логика взаимодействия для TechnologistWindow.xaml
    /// </summary>
    public partial class TechnologistWindow : Window
    {
        public TechnologistWindow()
        {
            InitializeComponent();
            var vm = new TechnologistWindowVM();
            DataContext = vm;
        }
    }
}