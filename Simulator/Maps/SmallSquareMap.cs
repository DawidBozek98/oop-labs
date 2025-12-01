namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    private readonly Rectangle _bounds;

    public int Size { get; }

    public SmallSquareMap(int size)
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException(
                nameof(size),
                "Size must be between 5 and 20."
            );
        }

        Size = size;

        _bounds = new Rectangle(0, 0, Size - 1, Size - 1);
    }

    public override bool Exist(Point p) =>
        _bounds.Contains(p);

    public override Point Next(Point p, Direction d)
    {
        var next = p.Next(d);
        return Exist(next) ? next : p;   // zatrzymujemy ruch
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        var next = p.NextDiagonal(d);
        return Exist(next) ? next : p;   // zatrzymujemy ruch
    }
}
