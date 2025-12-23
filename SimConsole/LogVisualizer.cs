using System;
using Simulator;

namespace SimConsole;

internal class LogVisualizer
{
    private readonly SimulationLog _log;

    public LogVisualizer(SimulationLog log)
    {
        _log = log ?? throw new ArgumentNullException(nameof(log));
    }

    public void Draw(int turnIndex)
    {
        if (turnIndex < 0 || turnIndex >= _log.TurnLogs.Count)
            throw new ArgumentOutOfRangeException(nameof(turnIndex));

        var turn = _log.TurnLogs[turnIndex];

        Console.Clear();

        int width = _log.SizeX;
        int height = _log.SizeY;

        DrawTopBorder(width);

        for (int y = 0; y < height; y++)
        {
            DrawRow(turn, y, width);

            if (y < height - 1)
                DrawMiddleBorder(width);
        }

        DrawBottomBorder(width);

        Console.WriteLine();
        Console.WriteLine($"Turn {turnIndex}: {turn.Mappable} -> {turn.Move}");
    }

    private static void DrawTopBorder(int width)
    {
        Console.Write(Box.TopLeft);
        for (int x = 0; x < width; x++)
        {
            Console.Write(new string(Box.Horizontal, 3));
            if (x < width - 1)
                Console.Write(Box.TopMid);
        }
        Console.WriteLine(Box.TopRight);
    }

    private static void DrawMiddleBorder(int width)
    {
        Console.Write(Box.MidLeft);
        for (int x = 0; x < width; x++)
        {
            Console.Write(new string(Box.Horizontal, 3));
            if (x < width - 1)
                Console.Write(Box.Cross);
        }
        Console.WriteLine(Box.MidRight);
    }

    private static void DrawBottomBorder(int width)
    {
        Console.Write(Box.BottomLeft);
        for (int x = 0; x < width; x++)
        {
            Console.Write(new string(Box.Horizontal, 3));
            if (x < width - 1)
                Console.Write(Box.BottomMid);
        }
        Console.WriteLine(Box.BottomRight);
    }

    private static void DrawRow(TurnLog turn, int y, int width)
    {
        Console.Write(Box.Vertical);

        for (int x = 0; x < width; x++)
        {
            var p = new Point(x, y);

            char c = ' ';
            if (turn.Symbols.TryGetValue(p, out var sym))
                c = sym;

            Console.Write($" {c} ");
            Console.Write(Box.Vertical);
        }

        Console.WriteLine();
    }
}
