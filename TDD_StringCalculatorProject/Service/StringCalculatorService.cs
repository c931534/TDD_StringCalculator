using System.Net.Sockets;

namespace TDD_StringCalculatorProject.Service;

public class StringCalculatorService
{
    public int Add(string numbers)
    {
        if (!string.IsNullOrWhiteSpace(numbers))
        {
            var splitChar = ",";
            var splitNumber = 0;
            if (IsNumberSplitByChangeLine(numbers, out string[] splitArray))
            {
                if (!int.TryParse(splitArray[0], out splitNumber))
                {
                    splitChar = splitArray[0].Substring(splitArray[0].Length - 1);
                }
            }

            return (splitArray.Length > 1
                       ? SplitString(splitArray[1], splitChar)
                       : SplitString(numbers, splitChar))
                   .Where(s => int.TryParse(s, out _)) // 過濾掉非數字項目
                   .Sum(s => Convert.ToInt32(s))
                   + splitNumber;
        }

        return 0;
    }

    private List<string> SplitString(string numbers, string splitChar)
    {
        return numbers.Split(splitChar).ToList();
    }

    private bool IsNumberSplitByChangeLine(string numbers, out string[] splitResult)
    {
        splitResult = numbers.Split("\n");
        return numbers.Split("\n").Length > 1;
    }
}