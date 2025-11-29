using Simulator;

namespace Runner;

internal class Program
{
    static void Main(string[] args)
    {
        Console.Write("Starting Simulator!\n");



        object s = "I am object";
        object i = 5;
        object e = new Elf() { Name = "Legolas", Agility = 3 };
        object[] objects = { s, i, e };

        foreach (var o in objects)
        {
            Console.WriteLine($"{o.GetType(),-15}: {o}");
        }


        TestObjectsToString();

        static void TestObjectsToString()
        {
            object[] myObjects = {
        new Animals() { Description = "dogs"},
        new Birds { Description = "  eagles ", Size = 10 },
        new Elf("e", 15, -3),
        new Orc("morgash", 6, 4)
    };
            Console.WriteLine("\nMy objects:");
            foreach (var o in myObjects) Console.WriteLine(o);



            //TestCreatures();
            //TestDirections();
            //TestElfsAndOrcs();
            //TestValidators();




            /* static void TestElfsAndOrcs()
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

             static void TestValidators()
             {
                 Console.WriteLine("\nVALIDATORS TEST\n");

                 Creature c = new Elf() { Name = "   Shrek    ", Level = 20 };
                 c.SayHi();
                 c.Upgrade();
                 Console.WriteLine(c.Info);

                 c = new Elf("  ", -5);
                 c.SayHi();
                 c.Upgrade();
                 Console.WriteLine(c.Info);

                 c = new Elf("  donkey ") { Level = 7 };
                 c.SayHi();
                 c.Upgrade();
                 Console.WriteLine(c.Info);

                 c = new Elf("Puss in Boots – a clever and brave cat.");
                 c.SayHi();
                 c.Upgrade();
                 Console.WriteLine(c.Info);

                 c = new Elf("a                            troll name", 5);
                 c.SayHi();
                 c.Upgrade();
                 Console.WriteLine(c.Info);

                 var a = new Animals() { Description = "   Cats " };
                 Console.WriteLine(a.Info);

                 a = new() { Description = "Mice           are great", Size = 40 };
                 Console.WriteLine(a.Info);
             } */
        }
    }
}

