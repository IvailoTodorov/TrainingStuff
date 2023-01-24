var nums = Console.ReadLine().Split(",").Select(int.Parse).ToArray();
var val = int.Parse(Console.ReadLine());

int j = 0;
foreach (int i in nums)
{
    if (i != val)
    {
        nums[j++] = i;
    }
}

Console.WriteLine(j);