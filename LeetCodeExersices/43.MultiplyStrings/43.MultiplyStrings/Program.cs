using System.Numerics;

string num1 = Console.ReadLine();
string num2 = Console.ReadLine();

var first = BigInteger.Parse(num1);
var second = BigInteger.Parse(num2);

var result = first + second;

Console.WriteLine(result.ToString());