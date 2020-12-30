using System;
using System.Collections.Generic;
using System.Numerics;
using CustomMath;

namespace FibonacciMultiplicationTableConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter a number for the size of the Fibonacci multiplication table");

                string userInput = Console.ReadLine();
                int size;

                if (Int32.TryParse(userInput, out size))
                {
                    if (size == 0)
                    {
                        Console.WriteLine("No result for size of 0");
                    }
                    else
                    {
                        List<List<Int64>> multiplicationTable = Fibonacci.GetMultiplicationTable(size);
                        Console.WriteLine("  " + String.Join(" ", multiplicationTable[0].ToArray()));
                        for (int i = 1; i < multiplicationTable.Count; i++)
                        {
                            Console.WriteLine(String.Join(" ", multiplicationTable[i].ToArray()));
                        }
                    }
                   
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }

                Console.WriteLine();
            }

        }
    }
}
