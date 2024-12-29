using System;
using NUnit.Framework;
using TDD_StringCalculatorProject.Service;

namespace TDD_StringCalculatorProject.Tests.Service;

[TestFixture]
[TestOf(typeof(StringCalculatorService))]
public class StringCalculatorServiceTest
{
    private StringCalculatorService _stringCalculatorService;

    public StringCalculatorServiceTest()
    {
        _stringCalculatorService = new();
    }

    [Test]
    public void return_0_when_stringEmpty()
    {
        Assert.That(_stringCalculatorService.Add(string.Empty), Is.EqualTo(0));
    }

    [Test]
    public void return_sum()
    {
        Assert.That(_stringCalculatorService.Add("2,4"), Is.EqualTo(6));
    }

    [Test]
    public void return_sum_when_Single()
    {
        Assert.That(_stringCalculatorService.Add("24"), Is.EqualTo(24));
    }

    [Test]
    public void return_sum_with_changeline()
    {
        Assert.That(_stringCalculatorService.Add("1\n2,4"), Is.EqualTo(7));
    }

    [Test]
    public void return_sum_can_change_split()
    {
        Assert.That(_stringCalculatorService.Add("//;\n1;2"), Is.EqualTo(3));
    }
    
    [Test]
    public void return_sum_not_allow_negatives()
    {
        // Arrange
        var input = "//;\n1;2;-5";

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => _stringCalculatorService.Add(input));

        // Verify exception message
        Assert.That(ex.Message, Is.EqualTo("Negatives not allowed: -5"));
    }
}