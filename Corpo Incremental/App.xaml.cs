using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Windows;
using WPFGameEngine;

namespace CorpoIncremental;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
	public IHost? AppHost { get; private set; }

    public App()
    {
	        AppHost = Host.CreateDefaultBuilder()
			.ConfigureServices((context, services) =>
			{
				services.AddSingleton<Game>();
				services.AddSingleton<Player>();
				services.AddTransient<MainWindow>();
				services.AddTransient<WorkstationWindow>();
			})
			.Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
	{
		GameEngine.Start();
		Utils.SetDropDownMenuToBeRightAligned();

		await AppHost!.StartAsync();	
		var startingWindow = AppHost.Services.GetRequiredService<MainWindow>();
		startingWindow.Show();

		base.OnStartup(e);
	}


	protected override async void OnExit(ExitEventArgs e)
	{
		await AppHost!.StopAsync();
		base.OnExit(e);
	}
}

