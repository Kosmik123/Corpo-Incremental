using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace CorpoIncremental;

public class Game
{
    public Player Player { get; private set; }

    private readonly IServiceProvider _serviceProvider;
    private readonly IGameSaveService _gameSaveService;

    private readonly JsonSerializerOptions saveSerializerOptions = new()
	{
		WriteIndented = true
	};

    private static string FilePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CorpoIncremental", "save.json");

    public Game(IServiceProvider serviceProvider, IGameSaveService gameSaveService)
    {
        _serviceProvider = serviceProvider;
        _gameSaveService = gameSaveService; 
    }

    public string GetMoneyText() => $"{Player.Money:0.###}$";

    public void Start()
    {
        Player = LoadPlayer();

        Window? firstWindow = _serviceProvider.GetService<DistanceWindow>();
        firstWindow?.Show();
    }

    public async void Save()
    {
        await Task.Run(SavePlayerToFile);
        void SavePlayerToFile()
        {
            var data = JsonSerializer.Serialize(Player.Money, saveSerializerOptions);
            var directory = Directory.CreateDirectory(Path.GetDirectoryName(FilePath) ?? string.Empty);
            if (directory.Exists)
                File.WriteAllText(FilePath, data);
        }
    }

    private Player LoadPlayer()
    {
        double money = 0;
        if (File.Exists(FilePath))
        {
            var data = File.ReadAllText(FilePath);
            money = JsonSerializer.Deserialize<double>(data);
        }
        return new Player(money); 
    }

}
