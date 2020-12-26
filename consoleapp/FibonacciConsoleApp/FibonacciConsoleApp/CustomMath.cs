using System;
using System.Collections.Generic;
using System.Text;

namespace CustomMath
{
    public static class Fibonacci
    {
        public static List<double> GetSequence(int sequenceLength)
        {
            double firtValue = 0;
            double secondValue = 1;
            return GetSequence(firtValue, secondValue, sequenceLength);
        }

        public static List<double> GetSequence(double firstValue, double secondValue, int sequenceLength)
        {
            List<double> sequence = new List<double>();
            double tempValue = 0;

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

        public static List<List<double>> GetMultiplicationTable(int sequenceLength)
        {
            double firstValue = 0;
            double secondValue = 1;
            return GetMultiplicationTable(firstValue, secondValue, sequenceLength);
        }

        public static List<List<double>> GetMultiplicationTable(double firstValue, double secondValue, int sequenceLength)
        {
            List<List<double>> multiplicationTable = new List<List<double>>();
            if(sequenceLength > 0)
            {
                List<double> fibonacciSequence = GetSequence(firstValue, secondValue, sequenceLength);

                multiplicationTable.Add(fibonacciSequence);

                for (int i = 0; i < fibonacciSequence.Count; i++)
                {
                    List<double> tableRow = new List<double>();
                    double baseNumber = fibonacciSequence[i];
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
