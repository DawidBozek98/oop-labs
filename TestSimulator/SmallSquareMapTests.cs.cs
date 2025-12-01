using System;
using Simulator;
using Simulator.Maps;
using Xunit;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Theory]
    [InlineData(5)]
    [InlineData(10)]
    [InlineData(20)]
    public void Constructor_ValidSize_ShouldSetSize(int size)
    {
        // Arrange & Act
        var map = new SmallSquareMap(size);

        // Assert
        Assert.Equal(size, map.Size);
    }

    [Theory]
    [InlineData(4)]
    [InlineData(21)]
    public void Constructor_InvalidSize_ShouldThrowArgumentOutOfRange(int size)
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
    }

    [Fact]
    public void Exist_ShouldReturnTrue_ForPointsInsideBounds()
    {
        // Arrange
        var map = new SmallSquareMap(10);
        var inside1 = new Point(0, 0);
        var inside2 = new Point(9, 9);
        var inside3 = new Point(5, 3);

        // Act & Assert
        Assert.True(map.Exist(inside1));
        Assert.True(map.Exist(inside2));
        Assert.True(map.Exist(inside3));
    }

    [Fact]
    public void Exist_ShouldReturnFalse_ForPointsOutsideBounds()
    {
        // Arrange
        var map = new SmallSquareMap(10);

        // Act & Assert
        Assert.False(map.Exist(new Point(-1, 0)));
        Assert.False(map.Exist(new Point(0, -1)));
        Assert.False(map.Exist(new Point(10, 0)));
        Assert.False(map.Exist(new Point(0, 10)));
        Assert.False(map.Exist(new Point(10, 10)));
    }

    [Fact]
    public void Next_ShouldMoveInsideMap()
    {
        // Arrange
        var map = new SmallSquareMap(10);
        var p = new Point(5, 5);

        // Act
        var up = map.Next(p, Direction.Up);
        var right = map.Next(p, Direction.Right);
        var down = map.Next(p, Direction.Down);
        var left = map.Next(p, Direction.Left);

        // Assert
        Assert.Equal(new Point(5, 6), up);
        Assert.Equal(new Point(6, 5), right);
        Assert.Equal(new Point(5, 4), down);
        Assert.Equal(new Point(4, 5), left);
    }

    [Fact]
    public void Next_ShouldStopAtBorder()
    {
        // Arrange
        var map = new SmallSquareMap(10);

        var leftEdge = new Point(0, 5);
        var rightEdge = new Point(9, 5);
        var bottom = new Point(5, 0);
        var top = new Point(5, 9);

        // Act
        var left = map.Next(leftEdge, Direction.Left);
        var right = map.Next(rightEdge, Direction.Right);
        var down = map.Next(bottom, Direction.Down);
        var up = map.Next(top, Direction.Up);

        // Assert – zostajemy w miejscu
        Assert.Equal(leftEdge, left);
        Assert.Equal(rightEdge, right);
        Assert.Equal(bottom, down);
        Assert.Equal(top, up);
    }

    [Fact]
    public void NextDiagonal_ShouldMoveInsideMap_OrStopAtBorder()
    {
        // Arrange
        var map = new SmallSquareMap(10);
        var middle = new Point(5, 5);
        var corner = new Point(9, 9);

        // Act
        var diagFromMiddle = map.NextDiagonal(middle, Direction.Up);
        var diagFromCorner = map.NextDiagonal(corner, Direction.Up);

        // Assert
        Assert.Equal(new Point(6, 6), diagFromMiddle); // normalny ruch
        Assert.Equal(corner, diagFromCorner);          // wyjście poza mapę - stop
    }
}
