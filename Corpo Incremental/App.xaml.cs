using CorpoIncremental.Meters;
using CorpoIncremental.Seconds;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using UnitsIncremental;
using WPFGameEngine;

namespace CorpoIncremental;

public partial class App : Application
{
	private readonly IHost AppHost;

	public App()
	{
		AppHost = Host.CreateDefaultBuilder()
			.ConfigureServices(ConfigureServices)
			.Build();

		static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
		{
			services.AddSingleton<Game>();
			services.AddSingleton<IGameSaveService, GameSaveService>();

			AddUnitControllers(services);
			AddWindows(services);
		}
	}

	private static void AddWindows(IServiceCollection services)
	{
		services.AddSingleton<MetersWindow>();
		services.AddSingleton<SecondsWindow>();
	}

	private static void AddUnitControllers(IServiceCollection services)
	{
		AddUnitController<MetersController>(services);
		AddUnitController<SecondsController>(services);
	}

	private static void AddUnitController<T>(IServiceCollection services)
		where T : class, IUnitController
	{
		services.AddSingleton<T>();
		services.AddSingleton<IUnitController>(sp => sp.GetRequiredService<T>());
	}

	protected override async void OnStartup(StartupEventArgs e)
	{
		Utils.SetDropDownMenuToBeRightAligned();
		GameEngine.Start();

		await AppHost.StartAsync();
		var game = AppHost.Services.GetService<Game>();
		game!.Start();

		base.OnStartup(e);
	}

	protected override async void OnExit(ExitEventArgs e)
	{
		await AppHost.StopAsync();
		base.OnExit(e);
	}
}

