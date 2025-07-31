using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;

namespace WPFGameEngine;

public class GameWindow : Window, IGameWindow
{
	protected override void OnContentRendered(EventArgs e)
	{
		base.OnContentRendered(e);
		IGameWindow.openWindows.Add(this);
	}

	protected override void OnClosing(CancelEventArgs e)
	{
		base.OnClosing(e);
		if (IGameWindow.openWindows.Count == 1)
		{
			var result = MessageBox.Show("Do you really want to quit?", "Quitting", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
			if (result == MessageBoxResult.Cancel)
				e.Cancel = true;
		}
	}

	protected override void OnClosed(EventArgs e)
	{
		Debug.WriteLine("Close");
		base.OnClosed(e);
		IGameWindow.openWindows.Remove(this);
	}
}

public interface IGameWindow
{
	protected static readonly List<GameWindow> openWindows = [];
	public static IReadOnlyList<GameWindow> OpenWindows { get; } = openWindows.AsReadOnly();
}