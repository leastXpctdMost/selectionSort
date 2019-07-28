using System;
using System.Collections.Generic;

public class Program
{
    public static List<int> finalSortedList = new List<int>();
    public static int originalLengthOfArrayToSort;
    public static int[] randomArray;
    public static void Main()
    {
        // var arrayToSort = new int[] { 5, 2, 3, 1, 4, 6, 8, 7, 12, 10, 9, 11, -1, -2, 13 };
        Console.WriteLine(Environment.NewLine + "How many elements in the array?");
        int inputAnswer = int.Parse(Console.ReadLine());
        randomArray = CreateArray(inputAnswer);
        originalLengthOfArrayToSort = randomArray.Length;
        SelectionSort(randomArray);
        Console.WriteLine(Environment.NewLine);
        foreach (var number in finalSortedList)
        {
            Console.Write(number.ToString() + ", ");
        }
        Console.WriteLine(Environment.NewLine);
    }

    public static void SelectionSort(int[] arrayToSort)
    {
        List<int> currentRound = new List<int>();
        List<int> nextRound = new List<int>();

        int count = arrayToSort.Length - 1;
        int[] nextRoundArray = new int[count];

        // count will be used to decide how many times to loop
        int n = 0;
        int round = originalLengthOfArrayToSort;

        int[] arrayOfPairs = new int[2];
        int lowestNum = 0;
        int highestNum = 0;
        while (finalSortedList.Count < originalLengthOfArrayToSort - 1)
        {
            while (count > 0)
            {
                int positionA;
                int positionB;

                if (n == 0)
                {
                    positionA = arrayToSort[n];
                    positionB = arrayToSort[n + 1];
                    arrayOfPairs = SortPairs(positionA, positionB);
                }
                else
                {
                    positionA = arrayToSort[n + 1];
                    positionB = currentRound[n - 1];
                    arrayOfPairs = SortPairs(positionA, positionB);
                }

                lowestNum = arrayOfPairs[0];
                highestNum = arrayOfPairs[1];

                currentRound.Add(lowestNum);
                //nextRound.Add(highestNum);
                nextRoundArray[n] = highestNum;
                n++;
                count--;
            }
            finalSortedList.Add(lowestNum);
            round++;
            if (nextRoundArray.Length > 1)
            {
                SelectionSort(nextRoundArray);
            }
            else
            {
                finalSortedList.Add(nextRoundArray[0]);
            }
        }
    }
    public static int[] SortPairs(int first, int second)
    {
        int[] inputNumbers = new int[2];
        if (first <= second)
        {
            inputNumbers[0] = first;
            inputNumbers[1] = second;
        }
        else
        {
            inputNumbers[0] = second;
            inputNumbers[1] = first;
        }
        return inputNumbers;
    }

    public static int[] CreateArray(int numberOfElements)
    {
        int[] array = new int[numberOfElements];
        Random randNum = new Random();
        for (int i = 0; i < numberOfElements; i++)
        {
            int newNum = randNum.Next(-99999, 99999);
            array[i] = newNum;
        }
        return array;
    }
}