using System.Net.Sockets;

namespace TDD_StringCalculatorProject.Service;

public class StringCalculatorService
{
    public int Add(string intString)
    {
        if (!string.IsNullOrWhiteSpace(intString))
        {
            return intString.Split(',').Sum(s => Convert.ToInt32(s));
        }
        else
        {
            return 0;
        }
    }
}