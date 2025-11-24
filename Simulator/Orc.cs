namespace Simulator;

public class Orc : Creature
{
    private int _rage;
    private int _huntCount = 0;

    public int Rage
    {
        get => _rage;
        init
        {
            _rage = Validator.Limiter(value, 0, 10);
        }
    }

    public Orc() { }

    public Orc(string name, int level = 1, int rage = 0)
        : base(name, level)
    {
        Rage = rage;
    }

    public override void SayHi()
    {
        Console.WriteLine($"{Name} the Orc (Lvl {Level}, Rage {Rage})");
    }

    public void Hunt()
    {
        _huntCount++;
        Console.WriteLine($"{Name} hunts...");

        if (_huntCount % 2 == 0 && _rage < 10)
            _rage++;
    }

    public override int Power => 7 * Level + 3 * Rage;
}
