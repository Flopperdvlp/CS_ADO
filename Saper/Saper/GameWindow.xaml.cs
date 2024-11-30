using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Saper
{
    public partial class GameWindow : Window
    {
        private int gridSize;
        private int mineCount;
        private Button[,] cells;
        private bool[,] mines;
        private int[,] mineCounts;
        public GameWindow(int gridSize, int mineCount)
        {
            InitializeComponent();
            this.gridSize = gridSize;
            this.mineCount = mineCount;
            InitializeGame();
        }
        private void InitializeGame()
        {
            GameGrid.Children.Clear();
            cells = new Button[gridSize, gridSize];
            mines = new bool[gridSize, gridSize];
            mineCounts = new int[gridSize, gridSize];

            Random random = new Random();

            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Button button = new Button
                    {
                        FontSize = 16,
                        Tag = (i, j),
                        Height = 30,
                        Width = 30,
                    };
                    button.Click += Cell_Click;
                    GameGrid.Children.Add(button);
                    cells[i, j] = button;
                }
            }

            // Размещение мин
            for (int k = 0; k < mineCount; k++)
            {
                int x, y;
                do
                {
                    x = random.Next(gridSize);
                    y = random.Next(gridSize);
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
                    if (nx >= 0 && nx < gridSize && ny >= 0 && ny < gridSize)
                        mineCounts[nx, ny]++;
                }
            }
        }
        private void Cell_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null) return;
            var (x, y) = ((int, int))clickedButton.Tag;
            if (mines[x, y])
            {
                clickedButton.Content = "💣";
                RevealAllCells();
            }
            else
            {
                clickedButton.IsEnabled = false;
                int surroundingMines = mineCounts[x, y];
                clickedButton.Content = surroundingMines > 0 ? surroundingMines.ToString() : "";
            }
        }
        private void RevealAllCells()
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Button cell = cells[i, j];
                    if (mines[i, j])
                    {
                        cell.Content = "💣";
                    }
                    else
                    {
                        int surroundingMines = mineCounts[i, j];
                        cell.Content = surroundingMines > 0 ? surroundingMines.ToString() : "";
                        cell.IsEnabled = false;
                    }
                }
            }
        }
    }
}