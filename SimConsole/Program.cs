using System.Text;
using Simulator;
using Simulator.Maps;


namespace SimConsole;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;  // żeby box-drawing działało

        // dane z zadanaia
        SmallSquareMap map = new(5);
        List<IMappable> creatures =
        [
            new Orc("Gorbag"),
            new Elf("Elandor")
        ];
        List<Point> points =
        [
            new(2, 2),
            new(3, 1)
        ];
        string moves = "dlrludl";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer visualizer = new(simulation.Map);

        // główna pętla 
        int turn = 0;

        while (!simulation.Finished)
        {
            visualizer.Draw();

            Console.WriteLine();
            Console.WriteLine($"Turn:     {turn + 1}");
            Console.WriteLine($"Creature: {simulation.CurrentCreature.Name}");
            Console.WriteLine($"Move:     {simulation.CurrentMoveName}");

            Console.WriteLine();
            Console.WriteLine("Press any key for next move...");
            Console.ReadKey(true);

            simulation.Turn();
            turn++;
        }

        // końcowy stan
        visualizer.Draw();
        Console.WriteLine();
        Console.WriteLine("Simulation finished!");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey(true);
    }
}
