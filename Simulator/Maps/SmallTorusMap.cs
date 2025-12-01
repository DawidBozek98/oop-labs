using System;

namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public int Size { get; }

    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException(
                nameof(size),
                "Size must be between 5 and 20."
            );
        }

        Size = size;
    }

    public override bool Exist(Point p)
    {
        return p.X >= 0 && p.X < Size
            && p.Y >= 0 && p.Y < Size;
    }

    public override Point Next(Point p, Direction d)
    {
        int x = p.X;
        int y = p.Y;

        switch (d)
        {
            case Direction.Up:
                y = (y + 1) % Size;
                break;
            case Direction.Down:
                y = (y - 1 + Size) % Size;
                break;
            case Direction.Right:
                x = (x + 1) % Size;
                break;
            case Direction.Left:
                x = (x - 1 + Size) % Size;
                break;
            default:
                return p;
        }

        return new Point(x, y);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        int x = p.X;
        int y = p.Y;

        int dx = 0;
        int dy = 0;

        // zgodnie z ruchem wskazówek 
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

        x = (x + dx + Size) % Size;
        y = (y + dy + Size) % Size;

        return new Point(x, y);
    }
}
