using Simulator;
using Simulator.Maps;

namespace SimConsole;

public class MapVisualizer
{
    private readonly Map _map;

    public MapVisualizer(Map map)
    {
        _map = map;
    }

    public void Draw()
    {
        Console.Clear();

        int width = _map.SizeX;
        int height = _map.SizeY;

        DrawTopBorder(width);

        for (int y = 0; y < height; y++)
        {
            DrawRow(y, width);

            if (y < height - 1)
                DrawMiddleBorder(width);
        }

        DrawBottomBorder(width);
    }

    private void DrawTopBorder(int width)
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

    private void DrawMiddleBorder(int width)
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

    private void DrawBottomBorder(int width)
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

    private void DrawRow(int y, int width)
    {
        Console.Write(Box.Vertical);

        for (int x = 0; x < width; x++)
        {
            var creatures = _map.At(x, y);   

            char c = ' ';
            if (creatures.Count == 1)
                c = creatures[0].Symbol;
            else if (creatures.Count > 1)
                c = 'X';                     // więcej niż jeden stwór

            Console.Write($" {c} ");
            Console.Write(Box.Vertical);
        }

        Console.WriteLine();
    }
}
