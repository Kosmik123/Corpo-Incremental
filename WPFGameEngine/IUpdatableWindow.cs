using System.Diagnostics;
using System;

namespace WPFGameEngine;

public interface IUpdatableWindow : IGameWindow
{
	void OnUpdate();
}

internal static class UpdatableWindowExtensions
{
	internal static void Update(this IUpdatableWindow window)
	{
		try
		{
			window.OnUpdate();
		}
		catch (Exception ex)
		{
			Debug.WriteLine($"Error in {nameof(window.OnUpdate)}: {ex.Message}");
		}
	}
}
