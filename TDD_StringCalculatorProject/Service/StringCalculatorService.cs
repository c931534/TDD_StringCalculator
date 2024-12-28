using System.Net.Sockets;

namespace TDD_StringCalculatorProject.Service;

public class StringCalculatorService
{
    public int Add(string numbers)
    {
        if (!string.IsNullOrWhiteSpace(numbers))
        {
            var changeLineSum = 0;

            var changeLineSplit = numbers.Split("\n");
            if (changeLineSplit.Length > 1)
            {
                changeLineSum = int.Parse(changeLineSplit[0]);
            }

            var commaList = changeLineSplit[1].Any()
                ? changeLineSplit[1].Split(",").ToList()
                : numbers.Split(",").ToList();
            return commaList
                .Where(s => int.TryParse(s, out _)) // 過濾掉非數字項目
                .Sum(s => Convert.ToInt32(s)) + changeLineSum;
        }

        return 0;
    }
}