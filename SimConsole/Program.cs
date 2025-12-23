using System.Text;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8; // żeby box-drawing działało

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== Simulator ===");
            Console.WriteLine("1) Sim1 (stara symulacja)");
            Console.WriteLine("2) Sim2 (zwierzęta na mapie)");
            Console.WriteLine("0) Wyjście");
            Console.Write("Wybór: ");

            var key = Console.ReadKey(true).KeyChar;

            if (key == '0')
                return;

            try
            {
                switch (key)
                {
                    case '1':
                        Sim1();
                        break;
                    case '2':
                        Sim2();
                        break;
                    default:
                        continue;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine($"Błąd: {ex.Message}");
                Console.WriteLine("Naciśnij dowolny klawisz...");
                Console.ReadKey(true);
            }
        }
    }

    private static void Sim1()
    {
        // tylko stwory
        Map map = new SmallSquareMap(5);

        List<IMappable> actors =
        [
            new Elf("Legolas", level: 3, agility: 8),
            new Orc("Gorbag", level: 2, rage: 5),
        ];

        List<Point> positions =
        [
            new Point(1, 1),
            new Point(3, 3),
        ];

        string moves = "URDLURDLUR"; 

        RunSimulation(new Simulation(map, actors, positions, moves));
    }

    private static void Sim2()
    {
        //  8 x 6
        Map map = new SmallTorusMap(8, 6);

        // wszystkie
        List<IMappable> actors =
        [
            new Elf("Elrond", level: 4, agility: 9),
            new Orc("Azog", level: 4, rage: 8),
            new Animals { Description = "Rabbits", Size = 6 },                 // A
            new Birds { Description = "Eagles", Size = 6, CanFly = true },     // B
            new Birds { Description = "Ostriches", Size = 6, CanFly = false }, // b
        ];

        List<Point> positions =
        [
            new Point(0, 0),
            new Point(2, 2),
            new Point(4, 1),
            new Point(7, 5),
            new Point(3, 4),
        ];

        string moves = "URDLURDLURDLURDLURDL"; 

        RunSimulation(new Simulation(map, actors, positions, moves));
    }

    private static void RunSimulation(Simulation simulation)
    {
        var visualizer = new MapVisualizer(simulation.Map);

        int turn = 1;

        while (!simulation.Finished)
        {
            visualizer.Draw();
            Console.WriteLine();
            Console.WriteLine($"Turn {turn}: {simulation.CurrentCreature.Name} -> {simulation.CurrentMoveName}");
            Console.WriteLine("Naciśnij dowolny klawisz, aby wykonać ruch...");
            Console.ReadKey(true);

            simulation.Turn();
            turn++;
        }

        visualizer.Draw();
        Console.WriteLine();
        Console.WriteLine("Simulation finished!");
        Console.WriteLine("Press any key to return to menu...");
        Console.ReadKey(true);
    }
}
