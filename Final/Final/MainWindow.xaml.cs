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
using static System.Net.Mime.MediaTypeNames;
using System.IO.Packaging;
using System.Windows.Media.Animation;
namespace Final
{
    public partial class MainWindow : Window
    {
        private string Path = "D:\\Desktop\\File.sql";
        public MainWindow()
        {
            InitializeComponent();
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            ContentGrid.Children.Clear();

            StackPanel searchPanel = new StackPanel();
            searchPanel.Children.Add(new TextBox { Text = "Введите заголовок записи для поиска", Margin = new Thickness(5), Foreground = Brushes.Gray });
            searchPanel.Children.Add(new Button { Content = "Найти", Margin = new Thickness(5) });

            ContentGrid.Children.Add(searchPanel);
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            ContentGrid.Children.Clear();

            StackPanel addPanel = new StackPanel();
            var titleTextBox = new TextBox { Margin = new Thickness(5), Foreground = Brushes.Gray };
            var textTextBox = new TextBox { Margin = new Thickness(5), Foreground = Brushes.Gray };
            var dateTextBox = new TextBox { Margin = new Thickness(5), Foreground = Brushes.Gray };

            addPanel.Children.Add(new TextBlock { Text = "Введите заголовок для записи", Margin = new Thickness(5) });
            addPanel.Children.Add(titleTextBox);
            addPanel.Children.Add(new TextBlock { Text = "Введите текст для записи", Margin = new Thickness(5) });
            addPanel.Children.Add(textTextBox);
            addPanel.Children.Add(new TextBlock { Text = "Введите время для записи", Margin = new Thickness(5) });
            addPanel.Children.Add(dateTextBox);

            Button addButton = new Button { Content = "Добавить", Margin = new Thickness(5) };
            addButton.Click += (s, args) => AddRecord(titleTextBox.Text, textTextBox.Text, dateTextBox.Text);
            addPanel.Children.Add(addButton);

            ContentGrid.Children.Add(addPanel);
        }
        private void ListButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ContentGrid.Children.Clear();

            StackPanel deletePanel = new StackPanel();
            deletePanel.Children.Add(new TextBox { Text = "Введите заголовок записи для удаления", Margin = new Thickness(5), Foreground = Brushes.Gray });
            deletePanel.Children.Add(new Button { Content = "Удалить", Margin = new Thickness(5) });

            ContentGrid.Children.Add(deletePanel);
        }
        private void AddRecord(string title, string text, string date)
        {
            string sqlInsert = $"INSERT INTO Records (Title, Text, Date) VALUES ('{title}', '{text}', '{date}');";
            File.AppendAllText(Path, sqlInsert + Environment.NewLine);
            MessageBox.Show("Запись добавлена!");
        }
    }
}