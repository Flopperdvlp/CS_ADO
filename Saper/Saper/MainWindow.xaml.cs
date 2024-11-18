using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
namespace Saper
{
    public partial class MainWindow : Window
    {
        private const int GridSize = 10; 
        private const int MineCount = 15;
        private Button[,] cells;
        private bool[,] mines;
        private int[,] mineCounts;
        private string logFilePath = "D:\\game_log.txt";
        public MainWindow()
        {
            InitializeComponent();
            InitializeGame();
        }
        private void InitializeGame()
        {
            GameGrid.Children.Clear();
            cells = new Button[GridSize, GridSize];
            mines = new bool[GridSize, GridSize];
            mineCounts = new int[GridSize, GridSize];
            Random random = new Random();
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    Button button = new Button
                    {
                        FontSize = 16,
                        Tag = (i, j)
                    };
                    button.Click += Cell_Click;
                    GameGrid.Children.Add(button);
                    cells[i, j] = button;
                }
            }
            for (int k = 0; k < MineCount; k++)
            {
                int x, y;
                do
                {
                    x = random.Next(GridSize);
                    y = random.Next(GridSize);
                } while (mines[x, y]);
                mines[x, y] = true;
                UpdateMineCounts(x, y);
            }
        }
        private void UpdateMineCounts(int x, int y)
        {
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    int nx = x + dx, ny = y + dy;
                    if (nx >= 0 && nx < GridSize && ny >= 0 && ny < GridSize)
                        mineCounts[nx, ny]++;
                }
            }
        }
        private void Cell_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null) 
                return;
            var (x, y) = ((int, int))clickedButton.Tag;
            if (mines[x, y])
            {
                clickedButton.Content = "💣";
                LogAction($"Mine clicked: ({x}, {y}) Game over");
                RevealAllCells();
            } else {
                clickedButton.IsEnabled = false;
                int surroundingMines = mineCounts[x, y];
                clickedButton.Content = surroundingMines > 0 ? surroundingMines.ToString() : "";
            }
        }
        private void RevealAllCells()
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    Button cell = cells[i, j];
                    if (mines[i, j])
                    {
                        cell.Content = "💣";
                    } else {
                        int surroundingMines = mineCounts[i, j];
                        cell.Content = surroundingMines > 0 ? surroundingMines.ToString() : "";
                        cell.IsEnabled = false;
                    }
                }
            }
        }
        private void LogAction(string message)
        {
            File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}{Environment.NewLine}");
        }
    }
}
