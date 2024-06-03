using System;

public abstract class Game
{
    public string Title { get; set; }
    public string Developers { get; set; }
    public int Year { get; set; }
    private bool availability;
    protected string genre;

    public Game(string title, string developers, int year, bool availability, string genre)
    {
        Title = title;
        Developers = developers;
        Year = year;
        this.availability = availability;
        this.genre = genre;
    }

    public void BuyGame()
    {
        if (availability)
        {
            availability = false;
            Console.WriteLine("'Thank you for the purchase!'");
        }
        else
        {
            Console.WriteLine("'We unfortunately do not have this game in stock.''");
        }
    }

  
    public abstract void DisplayGameInfo();
}

public class PCGame : Game
{
    public string Platform { get; private set; }

    public PCGame(string title, string developers, int year, bool availability, string genre, string platform)
        : base(title, developers, year, availability, genre)
    {
        Platform = platform;
    }

 
    public override void DisplayGameInfo()
    {
        Console.WriteLine($"Game: {Title}, Developers: {Developers}, Publication Year: {Year}, Genre: {genre}, Platform: {Platform}");
    }
}

public class ConsoleGame : Game
{
    public string ConsoleName { get; private set; }

    public ConsoleGame(string title, string developers, int year, bool availability, string genre, string consoleName)
        : base(title, developers, year, availability, genre)
    {
        ConsoleName = consoleName;
    }

    
    public override void DisplayGameInfo()
    {
        Console.WriteLine($"Game: {Title}, Developers: {Developers}, Publication Year: {Year}, Genre: {genre}, Console: {ConsoleName}");
    }
}

public class PlayStationGame : ConsoleGame
{
    public string PlayStationVersion { get; private set; }

    public PlayStationGame(string title, string developers, int year, bool availability, string genre, string consoleName, string playStationVersion)
        : base(title, developers, year, availability, genre, consoleName)
    {
        PlayStationVersion = playStationVersion;
    }

  
    public override void DisplayGameInfo()
    {
        Console.WriteLine($"Game: {Title}, Developers: {Developers}, Publication Year: {Year}, Genre: {genre}, Console: {ConsoleName}, PlayStation Version: {PlayStationVersion}");
    }
}

public class MobileGame : Game
{
    public string OperatingSystem { get; private set; }

    public MobileGame(string title, string developers, int year, bool availability, string genre, string operatingSystem)
        : base(title, developers, year, availability, genre)
    {
        OperatingSystem = operatingSystem;
    }


    public override void DisplayGameInfo()
    {
        Console.WriteLine($"Game: {Title}, Developers: {Developers}, Publication Year: {Year}, Genre: {genre}, Operating System: {OperatingSystem}");
    }
}

public interface IOnlineFeatures
{
    void ConnectToServer();
    void DownloadContent();
}

public class MultiplayerGame : Game, IOnlineFeatures
{
    public string ServerAddress { get; private set; }

    public MultiplayerGame(string title, string developers, int year, bool availability, string genre, string serverAddress)
        : base(title, developers, year, availability, genre)
    {
        ServerAddress = serverAddress;
    }


    public override void DisplayGameInfo()
    {
        Console.WriteLine($"Game: {Title}, Developers: {Developers}, Publication Year: {Year}, Genre: {genre}, Server Address: {ServerAddress}");
    }

 
    public void ConnectToServer()
    {
        Console.WriteLine($"Connecting to server at {ServerAddress}...");
    }

    public void DownloadContent()
    {
        Console.WriteLine("Downloading additional content...");
    }
}

public class Program
{
    static void Main(string[] args)
    {
        
        Game firstgame = new PCGame("Silent Hill", "Konami", 1999, true, "Horror", "Windows");
        Game secondgame = new PCGame("Minecraft", "Mojang", 2009, true, "Sandbox", "Windows");
        Game thirdgame = new PlayStationGame("The Last of Us Part II", "Naughty Dog", 2020, false, "Action-Adventure", "PlayStation", "PS4");
        Game fourthgame = new MobileGame("Clash of Clans", "Supercell", 2012, true, "Strategy", "IOS");
        MultiplayerGame fifthgame = new MultiplayerGame("Overwatch", "Blizzard", 2016, true, "First-Person Shooter", "us.overwatch.com");

        
        firstgame.DisplayGameInfo();
        firstgame.BuyGame();

        secondgame.DisplayGameInfo();
        secondgame.BuyGame();

        thirdgame.DisplayGameInfo();
        thirdgame.BuyGame();

        fourthgame.DisplayGameInfo();
        fourthgame.BuyGame();

        fifthgame.DisplayGameInfo();
        fifthgame.ConnectToServer();
        fifthgame.DownloadContent();
        fifthgame.BuyGame();
    }
}