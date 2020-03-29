using System;
using System.Linq;
using System.Threading.Tasks;

namespace Life.Run
{
    class Program
    {
        private static readonly Random Random = new Random();
        private const char SquareSymbol = '■';
        private const char Whitespace = ' ';
        private const int RefreshRateInSeconds = 1;

        static void Main(string[] args)
        {
            const int sideElementsCount = 20;
            const double densityCoefficient = 0.1d;

            var matrix = CreateMatrix(sideElementsCount);
            FillMatrix(matrix, densityCoefficient);

            while (!Console.KeyAvailable)
            {
                CalculateNextGeneration(matrix);
                DrawMatrix(matrix);
            }
        }

        private static void CalculateNextGeneration(bool[][] matrix)
        {
            //Implement your algorithm here
            FillMatrix(matrix, 0.2);
        }

        private static void FillMatrix(bool[][] matrix, double densityCoefficient)
        {
            foreach (var line in matrix)
                for (var i = 0; i < line.Length; i++)
                    line[i] = GetRandomLifeValue(densityCoefficient);
        }

        private static bool GetRandomLifeValue(double densityCoefficient) =>
            Random.NextDouble() > 1 - densityCoefficient;

        private static bool[][] CreateMatrix(int count)
        {
            var matrix = new bool[count][];
            foreach (var i in Enumerable.Range(0, count)) matrix[i] = new bool[count];

            return matrix;
        }

        private static void DrawMatrix(bool[][] matrix)
        {
            Task.Delay(RefreshRateInSeconds * 1000).Wait();
            Console.Clear();
            foreach (var line in matrix)
                for (var i = 0; i < line.Length; i++)
                {
                    Console.Write(Whitespace);
                    Console.Write(line[i] ? SquareSymbol : Whitespace);
                    Console.Write(Whitespace);
                    if (i == line.Length - 1) Console.WriteLine();
                }

            Console.Write(Environment.NewLine + Environment.NewLine + "Press any key to stop...");
        }
    }
}