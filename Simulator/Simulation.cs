namespace Simulator;

using System;
using System.Collections.Generic;
using Simulator.Maps;

public class Simulation
{
    public Map Map { get; }
    public List<IMappable> Creatures { get; }
    public List<Point> Positions { get; }
    public string Moves { get; }
    public bool Finished = false;

    private readonly List<Direction> _directions;
    private int _turnIndex;

    public IMappable CurrentCreature
    {
        get
        {
            if (Finished)
                throw new InvalidOperationException("Simulation is finished.");

            int creatureIndex = _turnIndex % Creatures.Count;
            return Creatures[creatureIndex];
        }
    }

    public string CurrentMoveName
    {
        get
        {
            if (Finished)
                throw new InvalidOperationException("Simulation is finished.");

            return _directions[_turnIndex].ToString().ToLower();
        }
    }

    public Simulation(Map map, List<IMappable> creatures, List<Point> positions, string moves)
    {
        Map = map ?? throw new ArgumentNullException(nameof(map));
        Creatures = creatures ?? throw new ArgumentNullException(nameof(creatures));
        Positions = positions ?? throw new ArgumentNullException(nameof(positions));

        if (Creatures.Count == 0)
            throw new ArgumentException("Creatures list cannot be empty.", nameof(creatures));

        if (Creatures.Count != Positions.Count)
            throw new ArgumentException("Creatures and positions collections must have the same number of elements.");

        Moves = moves ?? string.Empty;

        for (int i = 0; i < Creatures.Count; i++)
        {
            Creatures[i].InitMapAndPosition(Map, Positions[i]);
        }

        _directions = DirectionParser.Parse(Moves);
        _turnIndex = 0;
        Finished = _directions.Count == 0;
    }

    public void Turn()
    {
        if (Finished)
            throw new InvalidOperationException("Simulation is finished.");

        IMappable creature = CurrentCreature;
        Direction direction = _directions[_turnIndex];

        creature.Go(direction);

        _turnIndex++;

        if (_turnIndex >= _directions.Count)
            Finished = true;
    }
}
