namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; set; } = true;

    public override string Info
    {
        get
        {
            string fly = CanFly ? "fly+" : "fly-";
            return $"{Description} ({fly}) <{Size}>";
        }
    }
}
