using System.ComponentModel;
using System.Windows;
using WPFGameEngine;

namespace CorpoIncremental
{
    public partial class MainWindow : GameWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            MoneyText.Text = Game.Instance.GetMoneyText();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Game.Instance.Player.OnMoneyChanged += UpdateMoneyLabel;
        }

        private void WorkstationMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var workstationWindow = new WorkstationWindow();
            workstationWindow.Show();
        }

        private void UpdateMoneyLabel()
        {
            MoneyText.Text = $"{Game.Instance.GetMoneyText()}";
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            Game.Instance.Player.OnMoneyChanged -= UpdateMoneyLabel;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            SaveGame();
            base.OnClosing(e);
        }

        private void SaveGame()
        {
            Game.Instance.Save();
        }
    }
}
