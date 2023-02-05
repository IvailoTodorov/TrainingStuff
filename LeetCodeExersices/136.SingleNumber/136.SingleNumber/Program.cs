var nums = Console.ReadLine().Split(",").Select(int.Parse).ToArray();

var arr = nums.GroupBy(x => x).Where(g => g.Count() < 2).Select(y => y.Key).ToArray();

Console.WriteLine(String.Join(", ", arr));