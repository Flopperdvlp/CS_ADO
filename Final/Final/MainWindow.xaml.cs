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
            searchPanel.Children.OfType<Button>().First().Click += (s, args) =>
            {
                var inputTitle = searchPanel.Children.OfType<TextBox>().First().Text;
                Search(inputTitle);
            };
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
            List();
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ContentGrid.Children.Clear();
             
            StackPanel deletePanel = new StackPanel();
             
            deletePanel.Children.Add(new TextBox { Text = "Введите заголовок записи для удаления", Margin = new Thickness(5), Foreground = Brushes.Gray });
            deletePanel.Children.Add(new Button { Content = "Удалить", Margin = new Thickness(5) });
            deletePanel.Children.OfType<Button>().First().Click += (s, args) =>
            {
                var inputTitle = deletePanel.Children.OfType<TextBox>().First().Text;
                DeleteRecord(inputTitle);
            };
            
            ContentGrid.Children.Add(deletePanel);
        }
        private void AddRecord(string title, string text, string date)
        {
            string sqlInsert = $"INSERT INTO Records (Title, Text, Date) VALUES ('{title}', '{text}', '{date}');";
            File.AppendAllText(Path, sqlInsert + Environment.NewLine);
            MessageBox.Show("Запись добавлена!");
        }
        private void DeleteRecord(string title)
        {
            var lines = File.ReadAllLines(Path).ToList();
            var updatedLines = lines.Where(line => !line.Contains($"'{title}'")).ToList();
            File.WriteAllLines(Path, updatedLines);
            MessageBox.Show("Запись удалена!");
        }
        private void Search(string title)
        {
            ContentGrid.Children.Clear();
            var records = File.ReadAllLines(Path);
            var foundRecords = records.Where(line => line.Contains($"'{title}'")).ToList();
            StackPanel searchResultsPanel = new StackPanel();
            foreach (var record in foundRecords)
            {
                searchResultsPanel.Children.Add(new TextBlock { Text = record, Margin = new Thickness(5) });
            }

            ContentGrid.Children.Add(searchResultsPanel);
        }
        private void List()
        {
            ContentGrid.Children.Clear();
            string[] sqlCommands = File.ReadAllLines(Path);
            var insertCommands = sqlCommands.Where(line => line.StartsWith("INSERT INTO Records")).ToList();
            StackPanel listPanel = new StackPanel();
            foreach (var command in insertCommands)
            {
                listPanel.Children.Add(new TextBlock { Text = command, Margin = new Thickness(5) });
            }
            ContentGrid.Children.Add(listPanel);
        }
    }
}