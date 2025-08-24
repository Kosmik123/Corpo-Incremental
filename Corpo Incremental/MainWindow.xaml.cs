using System.ComponentModel;
using System.Windows;
using WPFGameEngine;

namespace CorpoIncremental
{
    public partial class MainWindow : GameWindow
    {

        public Game Game { get; }

        public MainWindow(Game game)
        {
            InitializeComponent();
            Game = game;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Game.Player.OnMoneyChanged += UpdateMoneyLabel;
        }

        private void UpdateMoneyLabel()
        {
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            Game.Player.OnMoneyChanged -= UpdateMoneyLabel;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            SaveGame();
            base.OnClosing(e);
        }

        private void SaveGame()
        {
            Game.Save();
        }
    }
}
