using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace TDD_StringCalculatorProject.Service;

public class StringCalculatorService
{
    public int Add(string numbers)
    {
        if (!string.IsNullOrWhiteSpace(numbers))
        {
            // 計算正整數的總和
            return Regex.Matches(numbers, @"\d+")
                .Select(m => int.Parse(m.Value))
                .ToList().Sum();
        }
        else
        {
            return 0;
        }
    }
}