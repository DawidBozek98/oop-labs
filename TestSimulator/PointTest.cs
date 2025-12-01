using Simulator;
using Xunit;

namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void Constructor_ShouldSetCoordinates()
    {
        // Act
        var p = new Point(3, 7);

        // Assert
        Assert.Equal(3, p.X);
        Assert.Equal(7, p.Y);
    }

    [Fact]
    public void ToString_ShouldReturnExpectedFormat()
    {
        var p = new Point(10, 25);
        Assert.Equal("(10, 25)", p.ToString());
    }

    [Theory]
    [InlineData(5, 5, Direction.Up, 5, 6)]
    [InlineData(5, 5, Direction.Right, 6, 5)]
    [InlineData(5, 5, Direction.Down, 5, 4)]
    [InlineData(5, 5, Direction.Left, 4, 5)]
    public void Next_ShouldMoveCorrectly(int x, int y, Direction d, int ex, int ey)
    {
        var p = new Point(x, y);

        var result = p.Next(d);

        Assert.Equal(new Point(ex, ey), result);
    }

    [Theory]
    [InlineData(5, 5, Direction.Up, 6, 6)]
    [InlineData(5, 5, Direction.Right, 6, 4)]
    [InlineData(5, 5, Direction.Down, 4, 4)]
    [InlineData(5, 5, Direction.Left, 4, 6)]
    public void NextDiagonal_ShouldMoveCorrectly(int x, int y, Direction d, int ex, int ey)
    {
        var p = new Point(x, y);

        var result = p.NextDiagonal(d);

        Assert.Equal(new Point(ex, ey), result);
    }
}
