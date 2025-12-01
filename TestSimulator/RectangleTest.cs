using System;
using Simulator;
using Xunit;

namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ShouldSortCoordinates()
    {
        // Arrange & Act
        var rect = new Rectangle(5, 5, 1, 1);

        // Assert
        Assert.Equal(1, rect.X1);
        Assert.Equal(1, rect.Y1);
        Assert.Equal(5, rect.X2);
        Assert.Equal(5, rect.Y2);
    }

    [Theory]
    [InlineData(1, 1, 1, 5)] // pion
    [InlineData(2, 3, 5, 3)] // poziom
    public void Constructor_CollinearPoints_ShouldThrow(int x1, int y1, int x2, int y2)
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
    }

    [Fact]
    public void Constructor_WithPoints_ShouldCallMainConstructor()
    {
        // Arrange
        var p1 = new Point(5, 5);
        var p2 = new Point(1, 1);

        // Act
        var rect = new Rectangle(p1, p2);

        // Assert
        Assert.Equal(1, rect.X1);
        Assert.Equal(1, rect.Y1);
        Assert.Equal(5, rect.X2);
        Assert.Equal(5, rect.Y2);
    }

    [Fact]
    public void Contains_ShouldReturnTrue_ForInsideAndEdges()
    {
        var rect = new Rectangle(1, 1, 3, 3);

        Assert.True(rect.Contains(new Point(1, 1))); // lewy dolny
        Assert.True(rect.Contains(new Point(3, 3))); // prawygórny
        Assert.True(rect.Contains(new Point(2, 2))); // środek
    }

    [Fact]
    public void Contains_ShouldReturnFalse_ForOutside()
    {
        var rect = new Rectangle(1, 1, 3, 3);

        Assert.False(rect.Contains(new Point(0, 0)));
        Assert.False(rect.Contains(new Point(4, 4)));
        Assert.False(rect.Contains(new Point(4, 2)));
        Assert.False(rect.Contains(new Point(2, 4)));
    }

    [Fact]
    public void ToString_ShouldReturnExpectedFormat()
    {
        var rect = new Rectangle(1, 2, 3, 4);
        Assert.Equal("(1, 2):(3, 4)", rect.ToString());
    }
}
