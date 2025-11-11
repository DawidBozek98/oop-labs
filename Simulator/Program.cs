namespace Simulator;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Starting Simulator!\n");

        /*   Elf e = new() { Name = "Elandor", Level = 5 };
           Creature e = new Elf("Elandor", 5, 7 );
           Console.WriteLine(e.GetType()); //zwraca typ obiektu 
           e.SayHi();
           e.Upgrade();
           Console.WriteLine(e.Info);
           //((Elf)e).Sing(); //     rzutowanie na typ Elf
           if (e is Elf elf) elf.Sing();
           else Console.WriteLine($"{e.Name} is not Elf");
           e.Go(Direction.Left);
           object o = 5;
           Console.WriteLine(o.GetType());*/

        object s = "I am object";
        object i = 5;
        object e = new Elf() { Name = "Legolas", Agility = 3 };
        object[] objects = { s, i, e };

        foreach (var o in objects)
        {
            Console.WriteLine($"{o.GetType(),-15}: {o}");
        }


    }


    
    
}
