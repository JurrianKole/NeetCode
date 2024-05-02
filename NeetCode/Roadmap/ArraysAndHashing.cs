namespace NeetCode.Roadmap;

public static class ArraysAndHashing
{
    // https://leetcode.com/problems/contains-duplicate/description/
    public static bool ContainsDuplicate(int[] nums)
    {
        var hashSet = new HashSet<int>();

        return !Array.TrueForAll(nums, hashSet.Add);
    }
    
    // https://leetcode.com/problems/valid-anagram/description/
    public static bool IsAnagram(string s, string t)
    {
        return s.OrderBy(c => c).SequenceEqual(t.OrderBy(c => c));
    }
    
    // https://leetcode.com/problems/two-sum/description/
    public static int[] TwoSum(int[] nums, int target)
    {
        var dictionary = new Dictionary<int, int>();
        
        for (var i = 0; i < nums.Length; i++)
        {
            dictionary.TryAdd(nums[i], i);
        }
        
        for (var i = 0; i < nums.Length; i++)
        {
            var remainder = target - nums[i];

            if (dictionary.TryGetValue(remainder, out var index) && index != i)
            {
                return [i, index];
            }
        }

        return Array.Empty<int>();
    }

    // https://leetcode.com/problems/group-anagrams/description/
    public static IList<IList<string>> GroupAnagrams(string[] strs)
    {
        var dictionary = new Dictionary<string, IList<string>>();

        foreach (var stringValue in strs)
        {
            var key = new string(stringValue.OrderBy(c => c).ToArray());
            
            if (dictionary.TryGetValue(key, out var anagrams))
            {
                anagrams.Add(stringValue);
            }
            else
            {
                dictionary.Add(key, new List<string> { stringValue });
            }
        }

        return dictionary.Select(d => d.Value).ToList();
    }

    // https://leetcode.com/problems/top-k-frequent-elements/description/
    public static int[] TopKFrequent(int[] nums, int k)
    {
        var dictionary = new Dictionary<int, int>();

        foreach (var number in nums)
        {
            if (!dictionary.TryAdd(number, 1))
            {
                dictionary[number]++;
            }
        }

        return dictionary
            .OrderByDescending(entry => entry.Value)
            .Take(k)
            .Select(entry => entry.Key)
            .ToArray();
    }
    
    // https://leetcode.com/problems/product-of-array-except-self/description/
    public static int[] ProductExceptSelf(int[] nums)
    {
        if (nums.Length == 2)
        {
            return [nums[1], nums[0]];
        }

        var result = new int[nums.Length];
        var product = 1;
        
        for (var i = 0; i < nums.Length; i++)
        {
            result[i] = product;
            product *= nums[i];
        }

        product = 1;

        for (var i = nums.Length - 1; i >= 0; i--)
        {
            result[i] *= product;
            product *= nums[i];
        }

        return result;
    }
}
