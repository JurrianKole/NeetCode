namespace NeetCode.Roadmap;

public static class TwoPointers
{
    // https://leetcode.com/problems/valid-palindrome/
    public static bool IsPalindrome(string s)
    {
        var inputString = new string(s.Where(char.IsAsciiLetterOrDigit).ToArray()).ToLowerInvariant();

        return !inputString.Where((t, i) => t != inputString[inputString.Length - 1 - i]).Any();
    }
    
    // https://leetcode.com/problems/two-sum-ii-input-array-is-sorted/description/
    public static int[] TwoSum(int[] numbers, int target)
    {
        var leftIndex = 0;
        var rightIndex = numbers.Length - 1;

        while (rightIndex > leftIndex)
        {
            if (numbers[leftIndex] + numbers[rightIndex] == target)
            {
                // 1-based index? Yuck
                return [leftIndex + 1, rightIndex + 1];
            }
            
            if (numbers[leftIndex] + numbers[rightIndex] > target)
            {
                rightIndex--;
                continue;
            }
            
            leftIndex++;
        }
        
        return Array.Empty<int>();
    }
}
