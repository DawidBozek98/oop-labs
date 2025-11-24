using Simulator;

public class Elf : Creature
{
    public int Agility { get; set; } = 1;
    public void Sing() => Console.WriteLine($"{Name} is singing.");

    public Elf(string name, int level = 1, int agility = 1) : base(name, level) //najpier wywoła się konstruktor bazowy
    {
        Agility = agility;
    }

    public Elf() { }
    public override void SayHi()
    {
        Console.WriteLine($"Hi! I'm {Name} (level {Level}, agility {Agility}.");
    }

    public override string ToString()
    {
        return($"{Name} <Level: {Level}, Agility: {Agility}>");
    }

}
