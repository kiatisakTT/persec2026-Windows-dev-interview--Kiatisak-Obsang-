using WindowsDeveloperInterview.Services;
using Xunit;

namespace WindowsDeveloperInterview.Tests;

public class ServiceTests
{
    [Theory]
    [InlineData("()", true)]
    [InlineData("([)]", false)]
    [InlineData("([()])", true)]
    [InlineData("(([[()]]))", false)] 
    [InlineData(")", false)]
    [InlineData("([])", false)] 
    [InlineData("(()]", false)]
    [InlineData("{", false)]
    public void Question1_BracketTest(string input, bool expected)
    {
        var service = new BracketService();
        Assert.Equal(expected, service.IsBalanced(input));
    }

    [Fact]
    public void Question2_AlphanumericSortTest()
    {
        var service = new SortingService();

        string[] array1 = { "TH19", "SG20", "TH2" };
        string[] expected1 = { "SG20", "TH2", "TH19" };
        Assert.Equal(expected1, service.SortAlphanumeric(array1));

        string[] array2 = { "TH10", "TH3Netflix", "TH1", "TH7" };
        string[] expected2 = { "TH1", "TH3Netflix", "TH7", "TH10" };
        Assert.Equal(expected2, service.SortAlphanumeric(array2));
    }

    [Fact]
    public void Question3_AutocompleteTest()
    {
        var service = new AutocompleteService();
        string[] items = { "Mother", "Think", "Worthy", "Apple", "Android" };

        string[] result = service.Search("th", items, 2);
        string[] expected = { "Think", "Mother" };

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1989, "MCMLXXXIX")]
    [InlineData(2000, "MM")]
    [InlineData(68, "LXVIII")]
    [InlineData(109, "CIX")]
    public void Question4_RomanNumeralTest(int intInput, string romanInput)
    {
        var service = new RomanNumeralService();
        Assert.Equal(romanInput, service.ToRoman(intInput));
        Assert.Equal(intInput, service.ToInt(romanInput));
    }

    [Theory]
    [InlineData(3008, 8300)]
    [InlineData(1989, 9981)]
    [InlineData(2679, 9762)]
    [InlineData(9163, 9631)]
    public void Question5_SortDigitsDescendingTest(int input, int expected)
    {
        var service = new SortingService();
        Assert.Equal(expected, service.SortDigitsDescending(input));
    }

    [Theory]
    [InlineData(new int[] { 1, 3, 5 }, 5, new int[] { 1, 3, 5, 9, 17 })]
    [InlineData(new int[] { 2, 2, 2 }, 3, new int[] { 2, 2, 2 })]
    [InlineData(new int[] { 10, 10, 10 }, 4, new int[] { 10, 10, 10, 30 })]
    public void Question6_TribonacciTest(int[] signature, int n, int[] expected)
    {
        var service = new TribonacciService();
        Assert.Equal(expected, service.GetSequence(signature, n));
    }
}