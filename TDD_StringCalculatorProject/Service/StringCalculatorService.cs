using System.Net.Sockets;

namespace TDD_StringCalculatorProject.Service;

public class StringCalculatorService
{
    public int Add(string intString)
    {
        if(string.IsNullOrWhiteSpace(intString))
            return 0;
        
        return 0;
    }
        
}