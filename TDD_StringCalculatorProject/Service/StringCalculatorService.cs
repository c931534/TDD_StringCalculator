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
                    splitChar = SetSplitChar(splitArray);
                }
            }

            var splitList = CombineSplitList(splitArray, splitChar, splitNumber);

            return splitList.Sum();
        }

        return 0;
    }

    private List<int> CombineSplitList(string[] splitArray, string splitChar, int splitNumber)
    {
        var splitStringList = GetSplitStringList(splitArray, splitChar);
        var intlist = new List<int>();

        foreach (var number in splitStringList)
        {
            var convertNumber = 0;
            if (int.TryParse(number, out convertNumber) && convertNumber < 0)
                throw new ArgumentException($"Negatives not allowed: {convertNumber}");
            intlist.Add(convertNumber);
        }

        intlist.Add(splitNumber);
        return intlist.Where(x => x < 1000).ToList();
    }

    private string SetSplitChar(string[] splitArray)
    {
        string splitChar;
        splitChar = splitArray[0].Substring(splitArray[0].Length - 1);
        if (splitArray[0].Contains('['))
        {
            splitChar = splitArray[0].Substring(3, splitArray[0].Length - 4);
        }

        return splitChar;
    }

    private List<string> GetSplitStringList(string[] splitArray, string splitChar)
    {
        return splitArray.Length > 1
            ? SplitString(splitArray[1], splitChar)
            : SplitString(splitArray[0], splitChar);
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