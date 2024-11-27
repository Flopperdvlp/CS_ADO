using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.IO;
namespace Saper
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void EasyButton_Click(object sender, RoutedEventArgs e)
        {
            OpenGameWindow(10, 10);
        }
        private void MediumButton_Click(object sender, RoutedEventArgs e)
        {
            OpenGameWindow(15, 20);
        }
        private void HardButton_Click(object sender, RoutedEventArgs e)
        {
            OpenGameWindow(20, 30);
        }
        private void OpenGameWindow(int gridSize, int mineCount)
        {
            GameWindow gameWindow = new GameWindow(gridSize, mineCount);
            gameWindow.Show();
            this.Close(); 
        }
    }
}