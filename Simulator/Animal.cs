namespace Simulator;

using System;
using Simulator.Maps;

public class Animals : IMappable
{
    private string _description = "Unknown";

    protected Map? MapRef { get; private set; }
    protected Point PointRef { get; set; }

    public string Description
    {
        get => _description;
        init
        {
            var v = Validator.Shortener(value, 3, 15, '#');

            if (v.Length < 3)
                v = v.PadRight(3, '#');

            _description = v;
        }
    }

    public uint Size { get; set; } = 3;

    public virtual string Info => $"{Description} <{Size}>";

    // IMappable
    public virtual string Name => Description;
    public virtual char Symbol => 'A';
    public Point Position => PointRef;

    public void InitMapAndPosition(Map map, Point startingPosition)
    {
        if (map == null)
            throw new ArgumentNullException(nameof(map));
        if (!map.Exist(startingPosition))
            throw new ArgumentOutOfRangeException(nameof(startingPosition));
        if (MapRef != null)
            throw new InvalidOperationException("Animal is already placed on a map.");

        MapRef = map;
        PointRef = startingPosition;
        map.Add(this, startingPosition);
    }

    public virtual void Go(Direction direction)
    {
        if (MapRef == null)
            return;

        var nextPoint = MapRef.Next(PointRef, direction);
        MapRef.Move(this, nextPoint);
        PointRef = nextPoint;
    }

    public override string ToString()
    {
        string typeName = GetType().Name.ToUpper();
        return $"{typeName}: {Info}";
    }
}
