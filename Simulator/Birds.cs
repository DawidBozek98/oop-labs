namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; set; } = true;

    // latające = 'B', nieloty = 'b'
    public override char Symbol => CanFly ? 'B' : 'b';

    public override string Info
    {
        get
        {
            string fly = CanFly ? "fly+" : "fly-";
            return $"{Description} ({fly}) <{Size}>";
        }
    }

    public override void Go(Direction direction)
    {
        if (MapRef == null)
            return;

        if (CanFly)
        {
            var mid = MapRef.Next(PointRef, direction);
            var next = MapRef.Next(mid, direction);

            MapRef.Move(this, next);
            PointRef = next;
            return;
        }

        var diagonal = MapRef.NextDiagonal(PointRef, direction);
        MapRef.Move(this, diagonal);
        PointRef = diagonal;
    }
}
