namespace Simulator.Maps;

using System;
using System.Collections.Generic;

/// <summary>
/// Torus map (wrap-around). Moving past edges causes wrapping to opposite side.
/// Allows multiple creatures per position.
/// </summary>
public class SmallTorusMap : Map
{
    private readonly Dictionary<Point, List<IMappable>> _creatures = new();
    private readonly Dictionary<IMappable, Point> _positions = new();

    public int Size => SizeX;

    public SmallTorusMap(int size)
        : base(size, size)
    {
        if (size > 20)
            throw new ArgumentOutOfRangeException(nameof(size));
    }

    /// <summary>
    /// Computes next point with wrap-around.
    /// </summary>
    public override Point Next(Point p, Direction d)
    {
        var next = p.Next(d);

        int x = next.X;
        int y = next.Y;

        if (x < 0) x = SizeX - 1;
        else if (x >= SizeX) x = 0;

        if (y < 0) y = SizeY - 1;
        else if (y >= SizeY) y = 0;

        return new Point(x, y);
    }

    /// <summary>
    /// Computes next diagonal point with wrap-around.
    /// </summary>
    public override Point NextDiagonal(Point p, Direction d)
    {
        var next = p.NextDiagonal(d);

        int x = next.X;
        int y = next.Y;

        if (x < 0) x = SizeX - 1;
        else if (x >= SizeX) x = 0;

        if (y < 0) y = SizeY - 1;
        else if (y >= SizeY) y = 0;

        return new Point(x, y);
    }

    /// <summary>
    /// Adds a creature at a given point.
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
    /// Removes a creature from its current point.
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
    /// Returns all creatures present at the given point.
    /// </summary>
    public override List<IMappable> At(Point p)
    {
        if (_creatures.TryGetValue(p, out var list))
            return new List<IMappable>(list);

        return new List<IMappable>();
    }
}
