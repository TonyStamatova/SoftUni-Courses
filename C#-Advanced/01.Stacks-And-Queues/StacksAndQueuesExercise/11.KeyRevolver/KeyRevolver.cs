namespace _11.KeyRevolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KeyRevolver
    {
        public static void Main()
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            Stack<int> bullets = new Stack<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());
            Queue<int> locks = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());
            int money = int.Parse(Console.ReadLine());
            bool noLocksLeft = false;

            while (locks.Count > 0)
            {
                if (bullets.Count == 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    return;
                }

                int bulletsInBarrel = Math.Min(bullets.Count, barrelSize);

                while (bulletsInBarrel > 0)
                {
                    int bulletSize = bullets.Pop();
                    bulletsInBarrel--;
                    money -= bulletPrice;
                    int lockSize = locks.Peek();

                    if (bulletSize <= lockSize)
                    {
                        locks.Dequeue();
                        Console.WriteLine("Bang!");
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                    }

                    if (locks.Count == 0)
                    {
                        noLocksLeft = true;
                        break;
                    }
                }

                if (bullets.Count > 0 && bulletsInBarrel == 0)
                {
                    Console.WriteLine("Reloading!");
                }

                if (noLocksLeft)
                {
                    break;
                }

            }

            Console.WriteLine($"{bullets.Count} bullets left. Earned ${money}");
        }
    }
}
