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
            if (value == null)
                value = "Unknown";

            value = value.Trim();

            if (value.Length < 3)
                value = value.PadRight(3, '#');

            if (value.Length > 25)
                value = value[..25].TrimEnd();

            if (char.IsLower(value[0]))
                value = char.ToUpper(value[0]) + value[1..];

            _name = value;
        }
    }

    public int Level
    {
        get => _level;
        init
        {
            if (value < 1) _level = 1;
            else if (value > 10) _level = 10;
            else _level = value;
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
