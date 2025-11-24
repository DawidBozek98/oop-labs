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

    public string Info => $"{Description} <{Size}>";
}
