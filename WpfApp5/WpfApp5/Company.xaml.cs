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

namespace WpfApp5
{
    public partial class Company : Window
    {
        public Company()
        {
            InitializeComponent();
        }
        public void Back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void SaveCompany(object sender, RoutedEventArgs e)
        {
            string name = CompanyName.Text;
            string address = CompanyAddress.Text;

            // В реальном приложении можно добавить код для сохранения в базу данных или файл
            MessageBox.Show($"Company Saved:\nName: {name}\nAddress: {address}");
        }
    }
}
