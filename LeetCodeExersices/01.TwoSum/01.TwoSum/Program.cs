var nums = Console.ReadLine().Split(",").Select(int.Parse).ToArray();
var target = int.Parse(Console.ReadLine());

// 2,7,11,15

var arr = new int[2];

for (int i = 0; i < nums.Length; i++)
{
    for (int j = 0; j < nums.Length; j++)
    {
        if (nums[i] + nums[j] == target)
        {
            if (i == j)
            {
                continue;
            }

            arr[0] = i;
            arr[1] = j;
            break;
        }
    }

}

Console.WriteLine(String.Join(", ", arr));