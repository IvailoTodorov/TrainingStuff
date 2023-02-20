using System;
using System.Collections.Generic;
using System.IO;

class Solution
{
    static void Main(String[] args)
    {
        int i = 4;
        double d = 4.0;
        string s = "HackerRank ";


        // Declare second integer, double, and String variables.

        int first;
        double second;
        string text;

        // Read and save an integer, double, and String to your variables.

        first = int.Parse(Console.ReadLine());
        second = double.Parse(Console.ReadLine());
        text = Console.ReadLine();

        // Print the sum of both integer variables on a new line.

        Console.WriteLine(first + i);

        // Print the sum of the double variables on a new line.

        Console.WriteLine($"{(second + d):f1}");


        // Concatenate and print the String variables on a new line
        // The 's' variable above should be printed first.

        Console.WriteLine(s + text);

    }
}