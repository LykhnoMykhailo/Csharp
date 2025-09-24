using System.Text;

namespace Task4
{
    public static class Program
    {
        public static bool IsValidTriangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                return false;
            }

            return a + b > c && a + c > b && b + c > a;
        }

        public static double GetPerimeter(double a, double b, double c)
        {
            if (IsValidTriangle(a, b, c))
            {
                return a + b + c;
            }
            return 0.0;
        }

        public static double GetArea(double a, double b, double c)
        {
            if (IsValidTriangle(a, b, c))
            {
                double s = GetPerimeter(a, b, c) / 2;
                return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            }
            return 0.0;
        }

        public static string GetTriangleType(double a, double b, double c)
        {
            if (!IsValidTriangle(a, b, c))
            {
                return "Не є трикутником";
            }

            const double epsilon = 1e-9;

            double[] sides = { a, b, c };
            Array.Sort(sides);

            double sideA = sides[0];
            double sideB = sides[1];
            double sideC = sides[2];

            if (Math.Abs(sideA - sideB) < epsilon && Math.Abs(sideB - sideC) < epsilon)
            {
                return "рівносторонній";
            }

            if (Math.Abs(sideA * sideA + sideB * sideB - sideC * sideC) < epsilon)
            {
                return "прямокутний";
            }

            if (Math.Abs(sideA - sideB) < epsilon || Math.Abs(sideB - sideC) < epsilon)
            {
                return "рівнобедрений";
            }

            return "довільний";
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            double a1 = 3, b1 = 4, c1 = 5;
            Console.WriteLine($"\n--- Приклад для сторін {a1}, {b1}, {c1} ---");
            Console.WriteLine($"Трикутник дійсний: {IsValidTriangle(a1, b1, c1)}"); 
            Console.WriteLine($"Периметр: {GetPerimeter(a1, b1, c1)}");
            Console.WriteLine($"Площа: {GetArea(a1, b1, c1)}");
            Console.WriteLine($"Тип: {GetTriangleType(a1, b1, c1)}");

            double a2 = 6, b2 = 6, c2 = 6;
            Console.WriteLine($"\n--- Приклад для сторін {a2}, {b2}, {c2} ---");
            Console.WriteLine($"Трикутник дійсний: {IsValidTriangle(a2, b2, c2)}");
            Console.WriteLine($"Периметр: {GetPerimeter(a2, b2, c2)}");
            Console.WriteLine($"Площа: {GetArea(a2, b2, c2)}");
            Console.WriteLine($"Тип: {GetTriangleType(a2, b2, c2)}");

            double a3 = 1, b3 = 2, c3 = 5;
            Console.WriteLine($"\n--- Приклад для сторін {a3}, {b3}, {c3} ---");
            Console.WriteLine($"Трикутник дійсний: {IsValidTriangle(a3, b3, c3)}");
            Console.WriteLine($"Периметр: {GetPerimeter(a3, b3, c3)}");
            Console.WriteLine($"Площа: {GetArea(a3, b3, c3)}");
            Console.WriteLine($"Тип: {GetTriangleType(a3, b3, c3)}");
        }
    }
}
