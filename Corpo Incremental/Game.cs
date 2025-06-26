using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace CorpoIncremental
{
	public class GameController
    {
        private readonly GameEvent[] gameEvents = 
		{
            //new GameEvent(new MoneyAchievedTrigger(Game.Instance.Player, 0.10), null)
		};
    }

    public class Game
    {
        public static Game Instance { get; } = new Game();

        public Player Player { get; }

        private readonly JsonSerializerOptions saveSerializerOptions = new()
		{
			WriteIndented = true
		};

        private static string FilePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CorpoIncremental", "save.json");

        private Game()
        {
            Player = LoadPlayer();
        }

        public string GetMoneyText() => $"{Player.Money:0.###}$";

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

        private static Player LoadPlayer()
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
}
