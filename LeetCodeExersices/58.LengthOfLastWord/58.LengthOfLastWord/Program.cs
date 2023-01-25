string s = Console.ReadLine();

var list = s.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

var str = list.Last();

Console.WriteLine(str.Length);