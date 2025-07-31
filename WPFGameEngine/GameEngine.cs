using System;
using System.Windows.Threading;

namespace WPFGameEngine;

public delegate void UpdateEventHandler();

public static class GameEngine
{
	public static event UpdateEventHandler OnUpdate = delegate { };

	public static void Start()
	{
		gameTimer.Start();
		gameTimer.Tick += GameTimer_Tick;
	}

	private static readonly DispatcherTimer gameTimer = new DispatcherTimer
	{
		Interval = TimeSpan.FromMilliseconds(Time.DeltaTimeMiliseconds)
	};

	private static void GameTimer_Tick(object? sender, EventArgs e)
	{
		var currentTime = TimeOnly.FromDateTime(DateTime.Now);
		var deltaTime = currentTime - lastUpdateTime;
		double deltaTimeSeconds = deltaTime.TotalSeconds;

		Time.DeltaTimeDouble = deltaTimeSeconds;
		lastUpdateTime = currentTime;
		OnUpdate.Invoke();
	}

	private static TimeOnly lastUpdateTime = TimeOnly.FromDateTime(DateTime.Now);
}
