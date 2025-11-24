namespace Simulator;

public class Elf : Creature
{
    private int _agility;
    private int _singCount = 0;

    public int Agility
    {
        get => _agility;
        init
        {
            int v = value;
            if (v < 0) v = 0;
            if (v > 10) v = 10;
            _agility = v;
        }
    }

    public Elf() { }

    public Elf(string name, int level = 1, int agility = 0)
        : base(name, level)
    {
        Agility = agility;
    }

    public override void SayHi()
    {
        Console.WriteLine($"{Name} the Elf (Lvl {Level}, Agility {Agility})");
    }

    public void Sing()
    {
        _singCount++;
        Console.WriteLine($"{Name} sings...");

        if (_singCount % 3 == 0 && _agility < 10)
            _agility++;
    }

    public override int Power => 8 * Level + 2 * Agility;
}
