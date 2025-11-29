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

    public abstract string Info { get; }

    public abstract string Greeting();
    public abstract int Power { get; }

   public string Go(Direction direction) => $"{direction.ToString().ToLower()}";

    public string Go(Direction[] directions)
    {

       var result = new string[directions.Length];
        for (int i = 0; i < directions.Length; i++)
        {
            result[i] = Go(directions[i]);
        }
        return string.Join(", ", result);

    }

    public void Go(string input)
    {
        Direction[] parsed = DirectionParser.Parse(input);
        Go(parsed);
    }

    public override string ToString()
    {
        string typeName = GetType().Name.ToUpper(); 
        return $"{typeName}: {Info}";
    }
}
