namespace Simulator;

public class Animals
{
    private string _description = "Unknown";

    public string Description
    {
        get => _description;
        init
        {
            var v = Validator.Shortener(value, 3, 15, '#');

            if (v.Length < 3)
                v = v.PadRight(3, '#');

            _description = v;
        }
    }

    public uint Size { get; set; } = 3;

    public virtual string Info => $"{Description} <{Size}>";


    // ostatni commit
    public override string ToString()
    {
        string typeName = GetType().Name.ToUpper(); 
        return $"{typeName}: {Info}";
    }
}
