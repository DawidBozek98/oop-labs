namespace Simulator;

public static class DirectionParser
{
    public static Direction[] Parse(string input)
    {
        if (string.IsNullOrEmpty(input))
            return Array.Empty<Direction>();

        List<Direction> result = new();

        foreach (char ch in input.ToUpper())
        {
            switch (ch)
            {
                case 'U':
                    result.Add(Direction.Up);
                    break;
                case 'R':
                    result.Add(Direction.Right);
                    break;
                case 'D':
                    result.Add(Direction.Down);
                    break;
                case 'L':
                    result.Add(Direction.Left);
                    break;
            }
        }

        return result.ToArray();
    }
}
