namespace Simulator;

using System;
using Simulator.Maps;

public abstract class Creature : IMappable
{
    private string _name = "Unknown";
    private int _level = 1;
    private Map? map;
    private Point point;

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

    public Point Position => point;

    public Creature()
    {
    }

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

    public virtual char Symbol => '?';

    public void InitMapAndPosition(Map map, Point startingPosition)
    {
        if (map == null)
            throw new ArgumentNullException(nameof(map));
        if (!map.Exist(startingPosition))
            throw new ArgumentOutOfRangeException(nameof(startingPosition));
        if (this.map != null)
            throw new InvalidOperationException("Creature is already placed on a map.");

        this.map = map;
        point = startingPosition;
        map.Add(this, startingPosition);
    }

    public void Go(Direction direction)
    {
        if (map == null)
            return;

        var nextPoint = map.Next(point, direction);
        map.Move(this, nextPoint);
        point = nextPoint;
    }

    public override string ToString()
    {
        string typeName = GetType().Name.ToUpper();
        return $"{typeName}: {Info}";
    }
}
