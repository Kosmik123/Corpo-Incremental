using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WPFGameEngine;

namespace CorpoIncremental;

public partial class App : Application
{
	private readonly IHost? AppHost;

    public App()
    {
		AppHost = Host.CreateDefaultBuilder()
			.ConfigureServices((context, services) =>
			{
				services.AddSingleton<Game>();
				services.AddTransient<MainWindow>();
				services.AddTransient<WorkstationWindow>();
				services.AddSingleton<IGameSaveService, GameSaveService>();
            })
			.Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
	{
		GameEngine.Start();
		Utils.SetDropDownMenuToBeRightAligned();

		await AppHost!.StartAsync();
		var game = AppHost.Services.GetService<Game>();
		game!.Start();

        base.OnStartup(e);
	}


	protected override async void OnExit(ExitEventArgs e)
	{
		await AppHost!.StopAsync();
		base.OnExit(e);
	}
}

