namespace Simulator;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        object s = "I am object";
        object i = 5;
        object e = new Elf() { Name = "Legolas", Agility = 3 };
        object[] objects = { s, i, e };

        foreach (var o in objects)
        {
            Console.WriteLine($"{o.GetType(),-15}: {o}");
        }


        /*
        TestCreatures();
        TestDirections();
        */
        TestElfsAndOrcs();


        static void TestElfsAndOrcs()
        {
            Console.WriteLine("HUNT TEST\n");
            var o = new Orc() { Name = "Gorbag", Rage = 7 };
            o.SayHi();
            for (int i = 0; i < 10; i++)
            {
                o.Hunt();
                o.SayHi();  
            }

            Console.WriteLine("\nSING TEST\n");
            var e = new Elf("Legolas", agility: 2);
            e.SayHi();
            for (int i = 0; i < 10; i++)
            {
                e.Sing();
                e.SayHi();
            }

            Console.WriteLine("\nPOWER TEST\n");
            Creature[] creatures = {
        o,
        e,
        new Orc("Morgash", 3, 8),
        new Elf("Elandor", 5, 3)
    };
            foreach (Creature creature in creatures)
            {
                Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
            }
        }

    }

}
