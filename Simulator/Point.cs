namespace Simulator;

public readonly struct Point
{
    public readonly int X, Y;

    public Point(int x, int y) => (X, Y) = (x, y);

    public override string ToString() => $"({X}, {Y})";

    public Point Next(Direction direction) =>
        direction switch
        {
            Direction.Up => new Point(X, Y + 1),
            Direction.Right => new Point(X + 1, Y),
            Direction.Down => new Point(X, Y - 1),
            Direction.Left => new Point(X - 1, Y),
            _ => this // ciekawostka, deafult świeci się na czerwono i podpowiada to
        };

    // rotujemy o 45 stopni w prawo
    public Point NextDiagonal(Direction direction) =>
        direction switch
        {
            // Up - Up-Right
            Direction.Up => new Point(X + 1, Y + 1),
            // Right - Down-Right
            Direction.Right => new Point(X + 1, Y - 1),
            // Down - Down-Left
            Direction.Down => new Point(X - 1, Y - 1),
            // Left - Up-Left
            Direction.Left => new Point(X - 1, Y + 1),
            _ => this
        };
}
