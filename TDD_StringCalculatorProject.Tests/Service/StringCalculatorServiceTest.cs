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
    public void return_sum_with_other_split()
    {
        Assert.That(_stringCalculatorService.Add("1/n2,4"), Is.EqualTo(7));
    }
}