using UnitsIncremental;
using WPFGameEngine;

namespace CorpoIncremental.Meters;

public partial class MetersWindow : GameWindow, IUpdatableWindow
{
	public MetersWindow(MetersController metersController)
	{
		InitializeComponent();
		DataContext = data = new MetersWindowData(metersController);
		CenterScrollBar();
	}

	private void CenterScrollBar()
	{
		double center = (MetersScrollBar.Minimum + MetersScrollBar.Maximum) / 2;
		MetersScrollBar.Value = center;
	}

	private void GameWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
	{
		data.MetersController.OnChanged += MetersController_OnChanged;
	}

	private void MetersController_OnChanged()
	{
		MetersDisplay.Content = data.DistanceFormatted;
	}

	public void OnUpdate()
	{
		double epsilon = 0.01f * (MetersScrollBar.Maximum - MetersScrollBar.Minimum);
		if (data.currentScrollbarSide != ScrollBarSide.Right && MetersScrollBar.Value > MetersScrollBar.Maximum - epsilon)
		{
			data.currentScrollbarSide = ScrollBarSide.Right;
			Increment();
		}
		else if (data.currentScrollbarSide != ScrollBarSide.Left && MetersScrollBar.Value < MetersScrollBar.Minimum + epsilon)
		{
			data.currentScrollbarSide = ScrollBarSide.Left;
			Increment();
		}
	}

	private void Increment() => data.Increment();


	private void GameWindow_Unloaded(object sender, System.Windows.RoutedEventArgs e)
	{
		data.MetersController.OnChanged -= MetersController_OnChanged;
	}

	#region PrivateFields
	private MetersWindowData data;
	#endregion
}
