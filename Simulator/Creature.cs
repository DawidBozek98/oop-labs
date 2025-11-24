namespace Simulator;

public abstract class Creature
{
    private string _name = "Unknown";
    private int _level = 1;

    public string Name
    {
        get => _name;
        init
        {
            _name = Validator.Shortener(value, 3, 25, '#');
        }
    }

    public int Level
    {
        get => _level;
        init
        {
            _level = Validator.Limiter(value, 1, 10);
        }
    }

    public Creature() { }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public void Upgrade()
    {
        if (_level < 10)
            _level++;
    }

    public string Info => $"{Name} <{Level}>";

    public abstract void SayHi();
    public abstract int Power { get; }

    public void Go(Direction direction)
    {
        Console.WriteLine($"{Name} goes {direction.ToString().ToLower()}.");
    }

    public void Go(Direction[] directions)
    {
        foreach (var dir in directions) Go(dir);
    }

    public void Go(string input)
    {
        Direction[] parsed = DirectionParser.Parse(input);
        Go(parsed);
    }
}
