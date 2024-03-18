namespace NeetCode.Roadmap;

public static class Stack
{
    // https://leetcode.com/problems/valid-parentheses/description/
    public static bool ValidParentheses(string s)
    {
        if (s.Length < 2)
        {
            return false;
        }
        
        var parentheses = new Dictionary<char, char>
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' }
        };

        var stack = new Stack<char>();

        foreach (var character in s)
        {
            if (parentheses.TryGetValue(character, out var parenthesis))
            {
                stack.Push(parenthesis);
            }
            else
            {
                if (stack.Count == 0 || stack.Pop() != character)
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }
}
