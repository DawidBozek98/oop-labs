namespace Simulator.Maps;

using System;
using System.Collections.Generic;

/// <summary>
/// Base class for all rectangular maps used in the simulator.
/// Stores the size, boundaries and provides the API for movement
/// and creature placement.
/// </summary>
public abstract class Map
{
    private Dictionary<Point, List<IMappable>> _points;

    /// <summary>
    /// Width of the map (X dimension).
    /// </summary>
    public int SizeX { get; }

    /// <summary>
    /// Height of the map (Y dimension).
    /// </summary>
    public int SizeY { get; }

    /// <summary>
    /// Rectangle representing valid coordinates from (0,0) to (SizeX - 1, SizeY - 1).
    /// </summary>
    protected Rectangle Bounds { get; }

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5)
            throw new ArgumentOutOfRangeException(nameof(sizeX));
        if (sizeY < 5)
            throw new ArgumentOutOfRangeException(nameof(sizeY));

        SizeX = sizeX;
        SizeY = sizeY;
        Bounds = new Rectangle(0, 0, sizeX - 1, sizeY - 1);
    }

    /// <summary>
    /// Checks whether a given point exists within the boundaries of the map.
    /// </summary>
    public virtual bool Exist(Point p) => Bounds.Contains(p);

    /// <summary>
    /// Computes the next point in the given direction according to map rules.
    /// </summary>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Computes the diagonal next point (45° rotated direction).
    /// </summary>
    public abstract Point NextDiagonal(Point p, Direction d);

    /// <summary>
    /// Adds a creature to the map at a given point.
    /// The map must store this creature and track its position.
    /// </summary>
    public abstract void Add(IMappable creature, Point p);

    /// <summary>
    /// Removes a creature from its current position on the map.
    /// </summary>
    public abstract void Remove(IMappable creature);

    /// <summary>
    /// Moves a creature from its old point to a new one.
    /// </summary>
    public void Move(IMappable creature, Point p)
    {
        Remove(creature);
        Add(creature, p);
    }

    /// <summary>
    /// Returns the list of creatures standing at a given point.
    /// </summary>
    public abstract List<IMappable> At(Point p);

    /// <summary>
    /// Returns the list of creatures standing at coordinates (x, y).
    /// </summary>
    public List<IMappable>? At(int x, int y) => At(new Point(x, y));
}
