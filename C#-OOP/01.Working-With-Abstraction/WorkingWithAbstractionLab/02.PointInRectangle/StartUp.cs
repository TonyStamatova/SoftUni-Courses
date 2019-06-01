using System;
using System.Linq;

namespace _02.PointInRectangle
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var rectangleData = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var topLeft = new Point(rectangleData[0], rectangleData[1]);
            var bottomRight = new Point(rectangleData[2], rectangleData[3]);
            var rectang = new Rectangle(topLeft, bottomRight);

            var numberOfLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfLines; i++)
            {
                var pointCoordinates = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var newPoint = new Point(pointCoordinates[0], pointCoordinates[1]);

                if (rectang.Contains(newPoint))
                {
                    Console.WriteLine("True");
                }
                else
                {
                    Console.WriteLine("False");
                }
            }
        }
    }
}
