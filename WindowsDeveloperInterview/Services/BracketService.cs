using System.Collections.Generic;
using WindowsDeveloperInterview.Interfaces;

namespace WindowsDeveloperInterview.Services;

public class BracketService : IBracketService
{
    private static readonly Dictionary<char, char> BracketPairs = new()
    {
        { ')', '(' },
        { '}', '{' },
        { ']', '[' }
    };
    //ข้อ 1
    public bool IsBalanced(string input)
    {
        if (string.IsNullOrEmpty(input)) return true;

        var stack = new Stack<char>();
        foreach (char c in input)
        {
            if (BracketPairs.ContainsValue(c)) // หากเป็นวงเล็บเปิด
            {
                stack.Push(c);
            }
            else if (BracketPairs.ContainsKey(c)) // หากเป็นวงเล็บปิด
            {
                if (stack.Count == 0 || stack.Pop() != BracketPairs[c])
                    return false;
            }
        }
        return stack.Count == 0;
    }
}