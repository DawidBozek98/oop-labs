namespace Simulator.Maps;

using System;
using System.Collections.Generic;

/// <summary>
/// Square map with hard boundaries. Movement outside edges is blocked.
/// Allows multiple creatures to stand on the same point.
/// </summary>
public class SmallSquareMap : Map
{
    private readonly Dictionary<Point, List<IMappable>> _creatures = new();
    private readonly Dictionary<IMappable, Point> _positions = new();

    public int Size => SizeX;

    public SmallSquareMap(int size)
        : base(size, size)
    {
        if (size > 20)
            throw new ArgumentOutOfRangeException(nameof(size));
    }

    /// <summary>
    /// Computes the next point for straight movement.
    /// If moving outside boundaries, the creature stays in place.
    /// </summary>
    public override Point Next(Point p, Direction d)
    {
        var next = p.Next(d);
        return Exist(next) ? next : p;
    }

    /// <summary>
    /// Computes the next diagonal point.
    /// If outside map boundaries, remains in place.
    /// </summary>
    public override Point NextDiagonal(Point p, Direction d)
    {
        var next = p.NextDiagonal(d);
        return Exist(next) ? next : p;
    }

    /// <summary>
    /// Adds a creature to the map at the given point.
    /// Stores it in the internal structure.
    /// </summary>
    public override void Add(IMappable creature, Point p)
    {
        if (!Exist(p))
            throw new ArgumentOutOfRangeException(nameof(p));

        if (!_creatures.TryGetValue(p, out var list))
        {
            list = new List<IMappable>();
            _creatures[p] = list;
        }

        if (!list.Contains(creature))
            list.Add(creature);

        _positions[creature] = p;
    }

    /// <summary>
    /// Removes a creature from its current point on the map.
    /// </summary>
    public override void Remove(IMappable creature)
    {
        if (!_positions.TryGetValue(creature, out var point))
            return;

        if (_creatures.TryGetValue(point, out var list))
        {
            list.Remove(creature);
            if (list.Count == 0)
                _creatures.Remove(point);
        }

        _positions.Remove(creature);
    }

    /// <summary>
    /// Returns all creatures positioned at the given point.
    /// </summary>
    public override List<IMappable> At(Point p)
    {
        if (_creatures.TryGetValue(p, out var list))
            return new List<IMappable>(list);

        return new List<IMappable>();
    }
}
