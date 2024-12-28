using System.Net.Sockets;

namespace TDD_StringCalculatorProject.Service;

public class StringCalculatorService
{
    public int Add(string intString)
    {
        if (intString != null)
        {
            var split = intString.Split(',');
            var sum = 0;
            foreach (var s in split)
            {
                var number = Convert.ToInt32(s);
                sum += number;
            }
            return sum;
        }
        if(string.IsNullOrWhiteSpace(intString))
            return 0;
        
        return 0;
    }
        
}