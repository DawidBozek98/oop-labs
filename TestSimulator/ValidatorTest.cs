using Simulator;
using Xunit;

namespace TestSimulator;

public class ValidatorTests
{
    // limiter

    [Theory]
    [InlineData(5, 0, 10, 5)]   // w środku zakresu
    [InlineData(-5, 0, 10, 0)]  // poniżej min
    [InlineData(15, 0, 10, 10)] // powyżej max
    public void Limiter_ShouldClampValue(int value, int min, int max, int expected)
    {
        var result = Validator.Limiter(value, min, max);

        Assert.Equal(expected, result);
    }

    // shortener

    [Fact]
    public void Shortener_NullValue_ShouldReturnUnknown()
    {
        // Arrange
        string? input = null;

        // Act
        var result = Validator.Shortener(input, 1, 20, '#');

        // Assert
        Assert.Equal("Unknown", result);
    }

    [Fact]
    public void Shortener_ShouldTrimAndPadWithPlaceholder()
    {
        // Arrange
        string input = "  ab ";
        int min = 5;
        int max = 10;
        char placeholder = '#';

        // Act
        var result = Validator.Shortener(input, min, max, placeholder);

        Assert.Equal("Ab###", result);
    }

    [Fact]
    public void Shortener_ShouldTruncateToMaxLength()
    {
        // Arrange
        string input = "  VeryLongName   ";
        int min = 1;
        int max = 5;

        // Act
        var result = Validator.Shortener(input, min, max, '.');

        Assert.Equal("VeryL", result);
    }

    [Fact]
    public void Shortener_ShouldCapitalizeFirstLetter()
    {
        // Arrange
        string input = "  cat  ";

        // Act
        var result = Validator.Shortener(input, 1, 10, '.');

        Assert.Equal("Cat", result);
    }
}
