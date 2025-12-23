namespace Simulator;

using System;
using System.Collections.Generic;
using Simulator.Maps;

/// <summary>
/// Runs a simulation once and stores enough data to recreate the map state for any turn
/// without rerunning the simulation.
/// </summary>
public class SimulationLog
{
    private Simulation _simulation { get; }

    public int SizeX { get; }
    public int SizeY { get; }

    /// <summary>
    /// TurnLogs[0] stores the starting state (before any move).
    /// TurnLogs[i] for i>=1 stores the map state after i-th move,
    /// together with information about which object moved and what move it was.
    /// </summary>
    public List<TurnLog> TurnLogs { get; } = [];

    public SimulationLog(Simulation simulation)
    {
        _simulation = simulation ?? throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    private void Run()
    {
        TurnLogs.Add(new TurnLog
        {
            Mappable = "START",
            Move = "START",
            Symbols = CaptureSymbols(_simulation.Map)
        });

        while (!_simulation.Finished)
        {
            string mover = _simulation.CurrentCreature.ToString();
            string move = _simulation.CurrentMoveName.ToString();

            _simulation.Turn();

            TurnLogs.Add(new TurnLog
            {
                Mappable = mover,
                Move = move,
                Symbols = CaptureSymbols(_simulation.Map)
            });
        }
    }

    private static Dictionary<Point, char> CaptureSymbols(Map map)
    {
        var symbols = new Dictionary<Point, char>();

        for (int y = 0; y < map.SizeY; y++)
        {
            for (int x = 0; x < map.SizeX; x++)
            {
                var p = new Point(x, y);
                var items = map.At(p);

                if (items.Count == 1)
                    symbols[p] = items[0].Symbol;
                else if (items.Count > 1)
                    symbols[p] = 'X';
            }
        }

        return symbols;
    }
}

/// <summary>
/// State of map after single simulation turn.
/// </summary>
public class TurnLog
{
    /// <summary>
    /// Text representation of moving object in this turn.
    /// CurrentMappable.ToString()
    /// </summary>
    public required string Mappable { get; init; }

    /// <summary>
    /// Text representation of move in this turn.
    /// CurrentMoveName.ToString();
    /// </summary>
    public required string Move { get; init; }

    /// <summary>
    /// Dictionary of IMappable.Symbol on the map in this turn.
    /// </summary>
    public required Dictionary<Point, char> Symbols { get; init; }
}
