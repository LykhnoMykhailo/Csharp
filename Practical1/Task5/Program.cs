namespace Task5
{
    public static class Program
    {
        public static double GetAverage(int[] marks)
        {
            if (marks == null || marks.Length == 0)
            {
                return 0.0;
            }
            return marks.Average();
        }

        public static int GetMin(int[] marks)
        {
            if (marks == null || marks.Length == 0)
            {
                return 0;
            }
            return marks.Min();
        }

        public static int GetMax(int[] marks)
        {
            if (marks == null || marks.Length == 0)
            {
                return 0;
            }
            return marks.Max();
        }

        public static void PrintGroupStatistics(int[][] groups)
        {
            if (groups == null || groups.Length == 0)
            {
                Console.WriteLine("Масив груп порожній.");
                return;
            }

            for (int i = 0; i < groups.Length; i++)
            {
                int[] currentGroup = groups[i];
                if (currentGroup != null && currentGroup.Length > 0)
                {
                    double average = GetAverage(currentGroup);
                    int min = GetMin(currentGroup);
                    int max = GetMax(currentGroup);
                    Console.WriteLine($"Група {i + 1}: Середній = {average:F0}, Мінімальний = {min}, Максимальний = {max}");
                }
            }
        }

        public static void Main(string[] args)
        {
            int[][] groups = new int[3][];

            Random random = new Random();
            for (int i = 0; i < groups.Length; i++)
            {
                int studentCount = random.Next(10, 31);
                groups[i] = new int[studentCount];
                for (int j = 0; j < studentCount; j++)
                {
                    groups[i][j] = random.Next(50, 101);
                }
            }

            PrintGroupStatistics(groups);
        }
    }
}
