using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace TDD_StringCalculatorProject.Service;

public class StringCalculatorService
{
    public int Add(string numbers)
    {
        if (!string.IsNullOrWhiteSpace(numbers))
        {

            // 使用正則表達式提取正整數
            var matches = Regex.Matches(numbers, @"\d+");
            List<int> numberList = matches
                .Select(m => int.Parse(m.Value))
                .ToList();

            // 計算正整數的總和
            return numberList.Sum();
        }
        else
        {
            return 0;
        }
    }
}