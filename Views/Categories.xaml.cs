﻿using SEW.ViewModels;
using System.Windows.Controls;

namespace SEW
{
    public partial class Categories : Page
    {
        public Categories(MainWindow main)
        {
            DataContext = new CategoryVM(main);
            InitializeComponent();
        }
    }
}
