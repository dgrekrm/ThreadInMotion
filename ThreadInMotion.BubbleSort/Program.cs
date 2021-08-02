using System;

namespace ThreadInMotion.BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new int[] { 11, 93, 45, 98, 13, 55 };

            int iterationCount = 0;

            Console.WriteLine($"Iteration {iterationCount} => {string.Join(",", numbers)}");
            bool isCompleted = false;

            while (!isCompleted)
            {
                iterationCount++;
                for (int i = 0; i < numbers.Length; i++)
                {
                    if ((i < numbers.Length - 1) && (numbers[i] > numbers[i + 1]))
                    {
                        int temp = numbers[i];
                        numbers[i] = numbers[i + 1];
                        numbers[i + 1] = temp;
                    }
                }
                Console.WriteLine($"Iteration {iterationCount} => {string.Join(",", numbers)}");
                isCompleted = CheckSortingProcessIsOk(numbers);
            }

            Console.WriteLine("Process completed");
            Console.ReadLine();

        }

        private static bool CheckSortingProcessIsOk(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if ((i < numbers.Length - 1) && (numbers[i] > numbers[i + 1])) return false;
            }
            return true;
        }
    }
}
