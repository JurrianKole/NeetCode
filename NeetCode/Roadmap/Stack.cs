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

        var stack = new Stack<char>();
        
        foreach (var character in s)
        {
            if (IsOpeningParenthesis(character))
            {
                stack.Push(GetClosingParenthesis(character));
                
                continue;
            }
            
            if (stack.Count == 0 || stack.Pop() != character)
            {
                return false;
            }
        }

        return stack.Count == 0;

        static bool IsOpeningParenthesis(char c)
        {
            return c is '(' or '{' or '[';
        }

        static char GetClosingParenthesis(char c)
        {
            return c switch
            {
                '(' => ')',
                '[' => ']',
                '{' => '}',
                _ => throw new ArgumentOutOfRangeException(nameof(c))
            };
        }
    }

    // https://leetcode.com/problems/generate-parentheses/description/
    public static IList<string> GenerateParenthesis(int n)
    {
        if (n == 1)
        {
            return new[] { "()" };
        }

        var result = new List<string>();
        
        RecursivelyAddParentheses(string.Empty, 0, 0);

        return result;

        void RecursivelyAddParentheses(
            string accumulator,
            int openingParenthesisCount, 
            int closingParenthesisCount)
        {
            if (openingParenthesisCount == n && openingParenthesisCount == closingParenthesisCount)
            {
                result.Add(accumulator);
                return;
            }

            if (openingParenthesisCount < n)
            {
                RecursivelyAddParentheses(accumulator + "(", openingParenthesisCount + 1, closingParenthesisCount);
            }

            if (closingParenthesisCount < openingParenthesisCount)
            {
                RecursivelyAddParentheses(accumulator + ")", openingParenthesisCount, closingParenthesisCount + 1);
            }
        }
    }

    // https://leetcode.com/problems/daily-temperatures/description/
    public static int[] DailyTemperatures(int[] temperatures)
    {
        if (temperatures.Length == 1)
        {
            return [0];
        }

        var result = new int[temperatures.Length];

        var temperatureMap = temperatures
            .Select((temperature, day) => (temperature, day))
            .ToDictionary(tuple => tuple.day, tuple => tuple.temperature);

        for (var i = 0; i < temperatures.Length; i++)
        {
            var temperatureToExceed = temperatures[i];
            
            var dayDifference = temperatureMap.FirstOrDefault(t => t.Key > i && t.Value > temperatureToExceed).Key - i;

            if (dayDifference > 0)
            {
                result[i] = dayDifference;
            }
            
            temperatureMap.Remove(i);
        }
        
        return result;
    }
}
