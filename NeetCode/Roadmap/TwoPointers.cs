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
        
        return [];
    }

    // https://leetcode.com/problems/3sum/description/
    public static IList<IList<int>> ThreeSum(int[] nums)
    {
        const int SumTarget = 0;
        
        var result = new HashSet<(int, int, int)>();

        var orderedNums = nums.Order().ToArray();

        for (var i = 0; i + 2 < orderedNums.Length && orderedNums[i] <= SumTarget; i++)
        {
            var leftIndex = i + 1;
            var rightIndex = orderedNums.Length - 1;

            while (rightIndex > leftIndex)
            {
                var sum = orderedNums[i] + orderedNums[leftIndex] + orderedNums[rightIndex];

                if (sum == SumTarget)
                {
                    result.Add((orderedNums[i], orderedNums[leftIndex], orderedNums[rightIndex]));
                }

                if (sum > SumTarget)
                {
                    rightIndex--;
                    continue;
                }

                leftIndex++;
            }
        }

        IList<IList<int>> myResult = result.Select(t => (IList<int>)new List<int> { t.Item1, t.Item2, t.Item3 }).ToList();

        return myResult;
    }
    
    // https://leetcode.com/problems/container-with-most-water/description/
    public static int MaxArea(int[] height)
    {
        var leftPointer = 0;
        var rightPointer = height.Length - 1;
        var maximumArea = 0;

        while (leftPointer < rightPointer)
        {
            var maximumAreaCandidate = Math.Min(height[leftPointer], height[rightPointer]) * (rightPointer - leftPointer);

            if (maximumAreaCandidate > maximumArea)
            {
                maximumArea = maximumAreaCandidate;
            }

            if (height[leftPointer] <= height[rightPointer])
            {
                leftPointer++;
            }
            else
            {
                rightPointer--;
            }
        }
        
        return maximumArea;
    }
    
    // https://leetcode.com/problems/trapping-rain-water/description/
    public static int Trap(int[] height)
    {
        var amountOfTrappableWater = 0;

        var highestBarrierIndex = Array.FindIndex(height, n => n == height.Max());

        var maxPointerBarrierHeight = height[0];
        
        for (var i = 0; i < highestBarrierIndex; i++)
        {
            if (height[i] > maxPointerBarrierHeight)
            {
                maxPointerBarrierHeight = height[i];
            }
            
            var trappableRainWater = Math.Min(maxPointerBarrierHeight, height[highestBarrierIndex]) - height[i];

            amountOfTrappableWater += trappableRainWater > 0 ? trappableRainWater : 0;
        }

        maxPointerBarrierHeight = height[^1];
        
        for (var i = height.Length - 1; i > highestBarrierIndex; i--)
        {
            if (height[i] > maxPointerBarrierHeight)
            {
                maxPointerBarrierHeight = height[i];
            }
            
            var trappableRainWater = Math.Min(maxPointerBarrierHeight, height[highestBarrierIndex]) - height[i];

            amountOfTrappableWater += trappableRainWater > 0 ? trappableRainWater : 0;
        }
        
        return amountOfTrappableWater;
    }
}
