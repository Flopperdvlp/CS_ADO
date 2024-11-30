using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        private int playerRow = 0;
        private int playerColumn = 0;
        private Random random = new Random();
        private int playerHealth = 100;
        private int playerAttack = 10;
        public MainWindow()
        {
            InitializeComponent();
            PlaceItemsRandomly();
            Grid.SetRow(Player, playerRow);
            Grid.SetColumn(Player, playerColumn);
        }
        private void PlaceItemsRandomly()
        {
            PlaceAtRandomPosition(Enemy1);
            PlaceAtRandomPosition(Enemy2);
            PlaceAtRandomPosition(Coin);
            PlaceAtRandomPosition(Weapon);
        }
        private void PlaceAtRandomPosition(UIElement element)
        {
            int row, column;
            do
            {
                row = random.Next(0, 5);
                column = random.Next(0, 5);
            }
            while ((row == playerRow && column == playerColumn) || IsOccupied(row, column, element));

            Grid.SetRow(element, row);
            Grid.SetColumn(element, column);
        }
        private bool IsOccupied(int row, int column, UIElement elementToSkip)
        {
            foreach (UIElement element in GameGrid.Children)
            {
                if (element != elementToSkip &&
                    Grid.GetRow(element) == row &&
                    Grid.GetColumn(element) == column)
                {
                    return true;
                }
            }
            return false;
        }
        private void GameGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point clickPosition = e.GetPosition(GameGrid);
            int targetRow = (int)(clickPosition.Y / (GameGrid.ActualHeight / 5));
            int targetColumn = (int)(clickPosition.X / (GameGrid.ActualWidth / 5));
            playerRow = targetRow;
            playerColumn = targetColumn;
            Grid.SetRow(Player, playerRow);
            Grid.SetColumn(Player, playerColumn);
            CheckForInteraction();
        }
        private void CheckForInteraction()
        {
            if (IsOnSamePosition(Player, Coin))
            {
                GameGrid.Children.Remove(Coin);
                MessageBox.Show("Монета собрана!");
            }
            if (IsOnSamePosition(Player, Weapon))
            {
                GameGrid.Children.Remove(Weapon);
                playerAttack += 10;
                MessageBox.Show("Оружие собрано! Атака увеличена.");
            }
            if (IsOnSamePosition(Player, Enemy1))
            {
                StartBattle(Enemy1);
            }
            else if (IsOnSamePosition(Player, Enemy2))
            {
                StartBattle(Enemy2);
            }
        }
        private void StartBattle(UIElement enemy)
        {
            int enemyHealth = 20;
            while (playerHealth > 0 && enemyHealth > 0)
            {
                enemyHealth -= playerAttack;
                playerHealth -= 5;
            }
            if (playerHealth > 0)
            {
                GameGrid.Children.Remove(enemy);
                MessageBox.Show("Враг побежден!");
            }
            else
            {
                MessageBox.Show("Игрок проиграл.");
                Application.Current.Shutdown();
            }
        }
        private bool IsOnSamePosition(UIElement element1, UIElement element2)
        {
            return Grid.GetRow(element1) == Grid.GetRow(element2) && Grid.GetColumn(element1) == Grid.GetColumn(element2);
        }
    }
}
