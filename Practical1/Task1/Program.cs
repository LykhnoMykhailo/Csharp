namespace Task1
{
    using System;
    using System.Text;

    public class Program
    {


        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            Console.WriteLine("Введіть число:");
            string input = Console.ReadLine();


            if (int.TryParse(input, out int number))
            {
                string message = GetMessage(number);
                Console.WriteLine(message);
            }
            else
            {
                Console.WriteLine("Будь ласка, введіть коректне ціле число.");
            }
        }
        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }
        public static string GetMessage(int number)
        {
            if (IsEven(number))
            {
                return "Двері відкриваються!";
            }
            else
            {
                return "Двері зачинені...";
            }
        }


    }

}
