using NUnit.Framework;
using TDD_StringCalculatorProject.Service;

namespace TDD_StringCalculatorProject.Tests.Service;

[TestFixture]
[TestOf(typeof(StringCalculatorService))]
public class StringCalculatorServiceTest
{
    [Test]
    public void return_0_when_stringEmpty()
    {
        StringCalculatorService stringCalculatorService = new();
        var add = stringCalculatorService.Add(string.Empty);
        Assert.That(add, Is.EqualTo(0));
    }
}