using System.Net.Sockets;

namespace TDD_StringCalculatorProject.Service;

public class StringCalculatorService
{
    public int Add(string numbers)
    {
        if (!string.IsNullOrWhiteSpace(numbers))
        {
            var splitChar = string.Empty;

            var changeLineSplit = numbers.Split("\n");
            if (changeLineSplit.Length > 1)
            {
                splitChar = changeLineSplit[0].Substring(2);
            }

            var commaList = changeLineSplit[1].Any()
                ? changeLineSplit[1].Split(splitChar).ToList()
                : numbers.Split(splitChar).ToList();
            return commaList
                .Where(s => int.TryParse(s, out _)) // 過濾掉非數字項目
                .Sum(s => Convert.ToInt32(s));
        }

        return 0;
    }
}