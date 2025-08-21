using System;
using UnitsIncremental;
using WPFGameEngine;

namespace CorpoIncremental;
public enum ScrollbarSide
{
    Left = -1,
    None = 0,
    Right = 1,
}

public class DistanceWindowData
{
    public ScrollbarSide currentScrollbarSide;

    private readonly MetersController metersController = new();

    public string Distance => metersController.Distance.ToString("0.##");

    public DistanceWindowData()
    {
        metersController.Acceleration = 0.01;
    }

    public void Tick()
    {
        metersController.Tick();
    }

    public void AddMeters()
    {
        metersController.Distance += 0.01;
    }
}

public partial class DistanceWindow : GameWindow
{
    private DistanceWindowData data;

	public DistanceWindow()
	{
		InitializeComponent();
        DataContext = data = new DistanceWindowData();
	}

    private void OnLoaded(object sender, System.Windows.RoutedEventArgs e)
    {
        distanceScrollbar.Value = (distanceScrollbar.Minimum + distanceScrollbar.Maximum) / 2;
        GameEngine.OnUpdate += GameEngine_OnUpdate;
    }

    private void GameEngine_OnUpdate()
    {
        data.Tick();
    }

    private void DistanceScrollbar_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
    {
        double epsilon = 0.01f * (distanceScrollbar.Maximum - distanceScrollbar.Minimum);
        if (data.currentScrollbarSide != ScrollbarSide.Right && distanceScrollbar.Value > distanceScrollbar.Maximum - epsilon)
        {
            data.currentScrollbarSide = ScrollbarSide.Right;
            AddMeters();
        }
        else if (data.currentScrollbarSide != ScrollbarSide.Left && distanceScrollbar.Value < distanceScrollbar.Minimum + epsilon)
        {
            data.currentScrollbarSide = ScrollbarSide.Left;
            AddMeters();
        }
    }

    private void AddMeters()
    {
        data.AddMeters();
    }
}
