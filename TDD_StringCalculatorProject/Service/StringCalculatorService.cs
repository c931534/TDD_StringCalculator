using System.Net.Sockets;

namespace TDD_StringCalculatorProject.Service;

public class StringCalculatorService
{
    public int Add(string numbers)
    {
        if (!string.IsNullOrWhiteSpace(numbers))
        {
            var changeLineSum = 0;

            var changeLineSplit = numbers.Split("/n");
            if (changeLineSplit.Count() > 1)
            {
                changeLineSum = int.Parse(changeLineSplit[0]);
            }

            var commaList = new List<string>();
            if (changeLineSplit[1].Any())
                commaList = changeLineSplit[1].Split(",").ToList();
            else
                commaList = numbers.Split(",").ToList();
            return commaList
                .Where(s => int.TryParse(s, out _)) // 過濾掉非數字項目
                .Sum(s => Convert.ToInt32(s)) + changeLineSum;
        }
        else
        {
            return 0;
        }
    }
}