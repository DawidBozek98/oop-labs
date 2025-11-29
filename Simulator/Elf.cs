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
            _agility = Validator.Limiter(value, 0, 10);
        }
    }

    public Elf() { }

    public Elf(string name, int level = 1, int agility = 0)
        : base(name, level)
    {
        Agility = agility;
    }

    public override string Greeting()
    {
        return $"{Name} the Elf (Lvl {Level}, Agility {Agility})";
    }

    public void Sing()
    {
        _singCount++;
        

        if (_singCount % 3 == 0 && _agility < 10)
            _agility++;
    }

    public override int Power => 8 * Level + 2 * Agility;

    // ovverride z ostatniego commita
    public override string Info => $"{Name} [{Level}][{Agility}]";
}
