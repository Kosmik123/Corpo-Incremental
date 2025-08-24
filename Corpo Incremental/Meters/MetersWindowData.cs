using UnitsIncremental;

namespace CorpoIncremental.Meters;

public class MetersWindowData
{
	public ScrollBarSide currentScrollbarSide;

	private readonly MetersController _metersController;
	public MetersController MetersController => _metersController;

	public string DistanceFormatted => $"{_metersController.Distance:0.##}m";

	public MetersWindowData(MetersController metersController)
	{
		_metersController = metersController;
		_metersController.Acceleration = 0.01;
	}

	public void Increment()
	{
		_metersController.Distance += 0.01;
	}
}
