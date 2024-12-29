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

            var splitList = MergeSplitList( splitArray, splitChar, splitNumber);
            if (splitList.Any(number => int.TryParse(number, out splitNumber) && splitNumber < 0))
            {
                throw new ArgumentException($"Negatives not allowed: {splitNumber}");
            }

            return splitList.Where(s => int.TryParse(s, out _))
                .Sum(s => Convert.ToInt32(s));
        }

        return 0;
    }

    private List<string> MergeSplitList(string[] splitArray, string splitChar, int splitNumber)
    {
        var result = splitArray.Length > 1
            ? SplitString(splitArray[1], splitChar)
            : SplitString(splitArray[0], splitChar);
        result.Add(splitNumber.ToString());
        return result;
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