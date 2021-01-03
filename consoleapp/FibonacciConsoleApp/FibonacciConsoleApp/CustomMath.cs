using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CustomMath
{
    public static class Fibonacci
    {
        public static List<long?> GetSequence(int sequenceLength)
        {
            long firtValue = 0;
            long secondValue = 1;
            return GetSequence(firtValue, secondValue, sequenceLength);
        }

        public static List<long?> GetSequence(long firstValue, long secondValue, int sequenceLength)
        {
            List<long?> sequence = new List<long?>();
            long tempValue = 0;

            if(sequenceLength > 0)
            {
                sequence.Add(firstValue);

                if (sequenceLength > 1)
                {
                    sequence.Add(secondValue);
                }
            }


            for (int i = 2; i < sequenceLength; i++)
            {
                tempValue = firstValue + secondValue;
                sequence.Add(tempValue);

                firstValue = secondValue;
                secondValue = tempValue;
            }

            return sequence;
        }

        public static List<List<long?>> GetMultiplicationTable(int sequenceLength)
        {
            long firstValue = 0;
            long secondValue = 1;
            return GetMultiplicationTable(firstValue, secondValue, sequenceLength);
        }

        public static List<List<long?>> GetMultiplicationTable(long firstValue, long secondValue, int sequenceLength)
        {
            List<List<long?>> multiplicationTable = new List<List<long?>>();
            if(sequenceLength > 0)
            {
                List<long?> fibonacciSequence = GetSequence(firstValue, secondValue, sequenceLength);
                fibonacciSequence.Insert(0, null);

                multiplicationTable.Add(fibonacciSequence);

                for (int i = 1; i < fibonacciSequence.Count; i++)
                {
                    List<long?> tableRow = new List<long?>();
                    long? baseNumber = fibonacciSequence[i];
                    tableRow.Add(baseNumber);

                    for (int j = 1; j < fibonacciSequence.Count; j++)
                    {
                        tableRow.Add(baseNumber * fibonacciSequence[j]);
                    }

                    multiplicationTable.Add(tableRow);
                }
            }
            return multiplicationTable;
        }
    }
}
