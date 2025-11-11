namespace Simulator;

public class Creature
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
                value = value.Substring(0, 25).TrimEnd();

            if (value.Length < 3)
                value = value.PadRight(3, '#');

            if (char.IsLower(value[0]))
                value = char.ToUpper(value[0]) + value.Substring(1);

            _name = value;
        }
    }

    public int Level
    {
        get => _level;
        init
        {
            int v = value;
            if (v < 1) v = 1;
            if (v > 10) v = 10;
            _level = v;
        }
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature()
    {
    }

    public void Upgrade()
    {
        if (_level >= 10)
            return; 
        _level++;
    }

    public string Info => $"{Name} <{Level}>";

    public void SayHi()
    {
        Console.WriteLine($"Hi! I'm {Name} (level {Level}).");
    }
}