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
                        List<List<long?>> multiplicationTable = Fibonacci.GetMultiplicationTable(size);
                        for (int i = 0; i < multiplicationTable.Count; i++)
                        {
                            List<long?> row = multiplicationTable[i];
                            string stringRow = "";
                            for (int j = 0; j < row.Count; j++)
                            {
                                string currentValue = "";
                                if(row[j] == null)
                                {
                                    currentValue = " ";
                                }
                                else
                                {
                                    currentValue = row[j].ToString();
                                }
                                stringRow = stringRow + currentValue + " ";
                            }
                            Console.WriteLine(stringRow);
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
