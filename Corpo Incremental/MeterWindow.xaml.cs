using WPFGameEngine;

namespace CorpoIncremental;

public partial class DistanceWindow : GameWindow, IUpdatableWindow
{
	private enum ScrollBarSide
	{
		Left = -1,
		Center = 0,
		Right = 1, 
	}

	private ScrollBarSide lastSide = ScrollBarSide.Center;
	private double currentDistance = 0;

	public DistanceWindow()
	{
		InitializeComponent();
	}

	public void OnUpdate()
	{
		if (IsOnLeftSide() && lastSide != ScrollBarSide.Left)
		{
			lastSide = ScrollBarSide.Left;
			Increment();
		}
		else if (IsOnRightSide() && lastSide != ScrollBarSide.Right)
		{
			lastSide = ScrollBarSide.Right;
			Increment();
		}
	}

	private void Increment()
	{
		currentDistance += 0.01;
		MetersDisplay.Content = $"{currentDistance.ToString("F2")}m";
	}

	private bool IsOnLeftSide()
	{
		return MetersScrollBar.Value <= 1.01f * MetersScrollBar.Minimum;
	}

	private bool IsOnRightSide()
	{
		return MetersScrollBar.Value >= 0.99f * MetersScrollBar.Maximum;
	}
}
