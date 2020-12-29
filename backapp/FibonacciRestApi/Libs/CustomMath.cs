using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace CustomMath
{
    public static class Fibonacci
    {
        public static List<BigInteger> GetSequence(int? sequenceLength)
        {
            BigInteger firtValue = 0;
            BigInteger secondValue = 1;
            return GetSequence(firtValue, secondValue, sequenceLength);
        }

        public static List<BigInteger> GetSequence(BigInteger firstValue, BigInteger secondValue, int? sequenceLength)
        {
            List<BigInteger> sequence = new List<BigInteger>();
            BigInteger tempValue = 0;

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

        public static List<List<BigInteger>> GetMultiplicationTable(int? sequenceLength)
        {
            BigInteger firstValue = 0;
            BigInteger secondValue = 1;
            return GetMultiplicationTable(firstValue, secondValue, sequenceLength);
        }

        public static List<List<BigInteger>> GetMultiplicationTable(BigInteger firstValue, BigInteger secondValue, int? sequenceLength)
        {
            List<List<BigInteger>> multiplicationTable = new List<List<BigInteger>>();
            if(sequenceLength > 0)
            {
                List<BigInteger> fibonacciSequence = GetSequence(firstValue, secondValue, sequenceLength);

                multiplicationTable.Add(fibonacciSequence);

                for (int i = 0; i < fibonacciSequence.Count; i++)
                {
                    List<BigInteger> tableRow = new List<BigInteger>();
                    BigInteger baseNumber = fibonacciSequence[i];
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
