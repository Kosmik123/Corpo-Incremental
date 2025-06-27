using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Threading;
using WPFGameEngine;

namespace CorpoIncremental
{
    public partial class WorkstationWindow : GameWindow
    {
        private readonly DispatcherTimer workTimer = new();
        private float workProgress;

        private double moneyPerClick = 0.01;

        private float workSpeed = 0.37f;

        public Game Game { get; }

        public WorkstationWindow(Game game)
        {
            Game = game;
            InitializeComponent();
            StopWorking();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            workTimer.Tick += WorkTimer_Tick;
        }

        private void WorkButton_Click(object sender, RoutedEventArgs e) => StartWorking();

        private void StartWorking()
        {
            workTimer.Interval = TimeSpan.FromMilliseconds(Time.DeltaTimeMiliseconds);
            workTimer.Start();
            WorkButton.IsEnabled = false;
            WorkButton.Content = "Working...";
            Debug.WriteLine("Start working");
        }

        private void WorkTimer_Tick(object? sender, EventArgs e)
        {
            workProgress += workSpeed * Time.DeltaTime;
            WorkProgressBar.Value = workProgress * WorkProgressBar.Maximum;
            if (workProgress >= 1)
                FinishWorking();
        }

        private void FinishWorking()
        {
            StopWorking();
            Game.Player.DoWork(moneyPerClick);
        }

        private void StopWorking()
        {
            workTimer.Stop();
            workProgress = 0;
            WorkProgressBar.Value = 0;
            WorkButton.Content = $"Work (+{moneyPerClick:0.##}$)";
            WorkButton.IsEnabled = true;
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            workTimer.Tick -= WorkTimer_Tick;
        }
    }
}
