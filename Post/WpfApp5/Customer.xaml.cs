using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class Customer : Window
    {
        private string path = "D:\\Desktop\\User.sql";
        public Customer()
        {
            InitializeComponent();
        }
        public void Back(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        private void SaveCustomer(object sender, RoutedEventArgs e)
        {
            string name = CustomerName.Text;
            string address = CustomerEmail.Text;
            AddRecord(name, address);
            MessageBox.Show($"Company Saved:\nName: {name}\nAddress: {address}");
        }
        private void AddRecord(string name, string email)
        {
            string gsqlinsert = $"INSERT INTO Records (Name, Email) VALUES ('{name},' {email}');";
            File.AppendAllText(path, gsqlinsert + Environment.NewLine);
            MessageBox.Show("Запись добавлена!");
        }
    }
}