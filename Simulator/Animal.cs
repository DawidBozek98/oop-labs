namespace Simulator;

public class Animals
{
    private string _description = "Unknown";

    public string Description
    {
        get => _description;
        init
        {
            if (value == null)
                value = "Unknown";

            value = value.Trim();

            if (value.Length < 3)
                value = value.PadRight(3, '#');

            if (value.Length > 15)
                value = value.Substring(0, 15).TrimEnd();

            if (value.Length < 3)
                value = value.PadRight(3, '#');

            if (char.IsLower(value[0]))
                value = char.ToUpper(value[0]) + value.Substring(1);

            _description = value;
        }
    }

    public uint Size { get; set; } = 3;

    public string Info => $"{Description} <{Size}>";
}
