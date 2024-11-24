using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
namespace WpfApp5
{
    public partial class MainWindow : Window
    {
        private string file_path = "D:\\Desktop\\User.sql";
        public MainWindow()
        {
            InitializeComponent();
        }
        public void Customer(object sender, RoutedEventArgs e) 
        {
            Customer customer = new Customer();
            customer.Show();
            this.Close();
        }
        public void Delivery(object sender, RoutedEventArgs e)
        {
            Delivery delivery = new Delivery();
            delivery.Show(); 
            this.Close();
        }
        public void Company(object sender, RoutedEventArgs e) 
        {
            Company company = new Company();
            company.Show();
            this.Close();
        }
        public void LoadSqlFile(object sender, RoutedEventArgs e)
        {
            try
            {
                if (File.Exists(file_path))
                {
                    string sqlContent = File.ReadAllText(file_path);
                    SqlContentTextBox.Text = sqlContent;
                }
                else
                {
                    MessageBox.Show($"Файл по пути {file_path} не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при чтении файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}  