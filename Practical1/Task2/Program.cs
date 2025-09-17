using System.Text;

namespace Task2
{
    public class Program
    {
        public static int[] GenerateRandomArray(int size, int min, int max)
        {
            Random rand = new Random();
            int[] numbers = new int[size];
            for (int i = 0; i < size; i++)
            {
                numbers[i] = rand.Next(min, max + 1);
            }
            return numbers;
        }
        public static int GetSum(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return 0;
            }

            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            return sum;
        }

        public static double GetAverage(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return 0.0;
            }

            return (double)GetSum(numbers) / numbers.Length;
        }
        public static int GetMin(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("Масив не може бути порожнім.");
            }

            int min = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }
            return min;
        }
        public static int GetMax(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                throw new ArgumentException("Масив не може бути порожнім.");
            }

            int max = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
            }
            return max;
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            const int arraySize = 10;
            const int minValue = 1;
            const int maxValue = 100;


            int[] randomNumbers = GenerateRandomArray(arraySize, minValue, maxValue);

 
            Console.WriteLine("Згенерований масив:");
            foreach (int number in randomNumbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
            

            int sum = GetSum(randomNumbers);
            double average = GetAverage(randomNumbers);
            int min = GetMin(randomNumbers);
            int max = GetMax(randomNumbers);

            Console.WriteLine($"Сума: {sum}");
            Console.WriteLine($"Середнє: {average:F2}"); 
            Console.WriteLine($"Мінімум: {min}");
            Console.WriteLine($"Максимум: {max}");
        }
    }
}
