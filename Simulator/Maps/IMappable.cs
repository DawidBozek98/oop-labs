namespace Simulator.Maps;

using Simulator;

public interface IMappable
{
    string Name { get; }
    char Symbol { get; }
    Point Position { get; }

    void InitMapAndPosition(Map map, Point startingPosition);
    void Go(Direction direction);

    string ToString();
}
