using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CustomMath
{
    public static class Fibonacci
    {
        public static List<Int64> GetSequence(int sequenceLength)
        {
            Int64 firtValue = 0;
            Int64 secondValue = 1;
            return GetSequence(firtValue, secondValue, sequenceLength);
        }

        public static List<Int64> GetSequence(Int64 firstValue, Int64 secondValue, int sequenceLength)
        {
            List<Int64> sequence = new List<Int64>();
            Int64 tempValue = 0;

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

        public static List<List<Int64>> GetMultiplicationTable(int sequenceLength)
        {
            Int64 firstValue = 0;
            Int64 secondValue = 1;
            return GetMultiplicationTable(firstValue, secondValue, sequenceLength);
        }

        public static List<List<Int64>> GetMultiplicationTable(Int64 firstValue, Int64 secondValue, int sequenceLength)
        {
            List<List<Int64>> multiplicationTable = new List<List<Int64>>();
            if(sequenceLength > 0)
            {
                List<Int64> fibonacciSequence = GetSequence(firstValue, secondValue, sequenceLength);

                multiplicationTable.Add(fibonacciSequence);

                for (int i = 0; i < fibonacciSequence.Count; i++)
                {
                    List<Int64> tableRow = new List<Int64>();
                    Int64 baseNumber = fibonacciSequence[i];
                    tableRow.Add(baseNumber);

                    for (int j = 0; j < fibonacciSequence.Count; j++)
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
