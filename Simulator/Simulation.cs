namespace Simulator;

using System;
using System.Collections.Generic;
using Simulator.Maps;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves.
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves,
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Parsed and filtered list of directions taken from Moves.
    /// Invalid move characters are ignored.
    /// </summary>
    private readonly List<Direction> _directions;

    /// <summary>
    /// Number of turns that has already been done.
    /// Also index of the next move in the _directions list.
    /// </summary>
    private int _turnIndex;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature
    {
        get
        {
            if (Finished)
                throw new InvalidOperationException("Simulation is finished.");

            int creatureIndex = _turnIndex % Creatures.Count;
            return Creatures[creatureIndex];
        }
    }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName
    {
        get
        {
            if (Finished)
                throw new InvalidOperationException("Simulation is finished.");

            return _directions[_turnIndex].ToString().ToLower();
        }
    }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
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
            Creature creature = Creatures[i];
            Point position = Positions[i];
            creature.InitMapAndPosition(Map, position);
        }

        _directions = DirectionParser.Parse(Moves);
        _turnIndex = 0;
        Finished = _directions.Count == 0;
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
            throw new InvalidOperationException("Simulation is finished.");

        Creature creature = CurrentCreature;
        Direction direction = _directions[_turnIndex];


        creature.Go(direction);

        _turnIndex++;

        if (_turnIndex >= _directions.Count)
            Finished = true;
    }
}
