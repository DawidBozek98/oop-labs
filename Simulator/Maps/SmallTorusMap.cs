namespace Simulator.Maps;

using System;
using System.Collections.Generic;

/// <summary>
/// Torus map (wrap-around). Moving past edges causes wrapping to opposite side.
/// Allows multiple creatures per position.
/// </summary>
public class SmallTorusMap : Map
{
    private readonly Dictionary<Point, List<Creature>> _creatures = new();
    private readonly Dictionary<Creature, Point> _positions = new();

    public int Size => SizeX;

    public SmallTorusMap(int size)
        : base(size, size)
    {
        if (size > 20)
            throw new ArgumentOutOfRangeException(nameof(size));
    }

    /// <summary>
    /// Computes wrapped straight movement (torus behavior).
    /// </summary>
    public override Point Next(Point p, Direction d)
    {
        int x = p.X;
        int y = p.Y;

        switch (d)
        {
            case Direction.Up:
                y++;
                break;
            case Direction.Right:
                x++;
                break;
            case Direction.Down:
                y--;
                break;
            case Direction.Left:
                x--;
                break;
            default:
                return p;
        }

        x = (x + SizeX) % SizeX;
        y = (y + SizeY) % SizeY;

        return new Point(x, y);
    }

    /// <summary>
    /// Computes wrapped diagonal movement (torus behavior).
    /// </summary>
    public override Point NextDiagonal(Point p, Direction d)
    {
        int dx, dy;

        switch (d)
        {
            case Direction.Up:
                dx = 1; dy = 1;
                break;
            case Direction.Right:
                dx = 1; dy = -1;
                break;
            case Direction.Down:
                dx = -1; dy = -1;
                break;
            case Direction.Left:
                dx = -1; dy = 1;
                break;
            default:
                return p;
        }

        int x = (p.X + dx + SizeX) % SizeX;
        int y = (p.Y + dy + SizeY) % SizeY;

        return new Point(x, y);
    }

    /// <summary>
    /// Adds a creature to the torus map at the given point.
    /// </summary>
    public override void Add(Creature creature, Point p)
    {
        if (!Exist(p))
            throw new ArgumentOutOfRangeException(nameof(p));

        if (!_creatures.TryGetValue(p, out var list))
        {
            list = new List<Creature>();
            _creatures[p] = list;
        }

        if (!list.Contains(creature))
            list.Add(creature);

        _positions[creature] = p;
    }

    /// <summary>
    /// Removes a creature from its stored position.
    /// </summary>
    public override void Remove(Creature creature)
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
    public override List<Creature> At(Point p)
    {
        if (_creatures.TryGetValue(p, out var list))
            return new List<Creature>(list);

        return new List<Creature>();
    }
}
