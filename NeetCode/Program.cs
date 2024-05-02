using NeetCode.Roadmap;

namespace NeetCode;

internal static class Program
{
    internal static void Main(string[] args)
    {
        var numbers = new[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };

        var result = TwoPointers.Trap(numbers);
        
        Console.WriteLine("Hello, World!");
    }
}
