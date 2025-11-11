using Simulator;
using System.Xml.Linq;

public class Orc : Creature
{
    public int Rage { get; set; } = 1;
    public void Hunt() => Console.WriteLine($"{Name} is hunting.");

    public Orc(string name, int level, int rage) : base(name, level)
    {
        Rage = rage;
    }



    public override void SayHi()
    {
        Console.WriteLine($"Hi! I'm {Name} (level {Level}, rage {Rage}.");
    }
}