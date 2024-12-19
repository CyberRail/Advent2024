using System.IO;
namespace AdvntOfCode;

public static partial class ChallengeSolutions
{
    public static void Challenge1()
    {
        string[] contents = File.ReadAllText($"{Directory.GetCurrentDirectory()}/Keys/Challenge1.txt").Split("\n");
        var (left, right) = contents
            .Select(content => content.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray())
            .Select(arr => (Left: arr[0], Right: arr[1]))
            .Aggregate(
                (left: new List<int>(), right: new List<int>()),
                (acc, val) => {
                    acc.left.Add(val.Left);
                    acc.right.Add(val.Right);
                    return acc;
                }
            );
        left.Sort();
        right.Sort();
        Span<int> leftSpan = new(left.ToArray(), 0, left.Count); 
        Span<int> rightSpan = new(right.ToArray(), 0, right.Count);
        int key = 0;

        for (int i = 0; i < left.Count; i++)
        {
            key += Math.Abs(leftSpan[i] - rightSpan[i]);
        }
        Console.WriteLine($"Key: {key}");
        //Console.WriteLine(contents);
    }
}
