using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace _01.KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            var priceForBullet = int.Parse(Console.ReadLine());
            var barrelSize = int.Parse(Console.ReadLine());
            var bulletsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var locksInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var barrel = new Queue<int>();
            var bullets = new Stack<int>(bulletsInput);
            var bulletsCount = bullets.Count;
            var locks = new Queue<int>(locksInput);
            var intelligence = int.Parse(Console.ReadLine());
            var bulletCounter = 0;

            while (true)
            {
                for (int i = 0; i < barrelSize; i++)
                {
                    var bullet = bullets.Pop();
                    barrel.Enqueue(bullet);
                    if (!bullets.Any())
                    {
                        break;
                    }
                }

                for (int i = 0; i < barrel.Count; i++)
                {
                    bulletCounter++;
                    var currentBullet = barrel.Dequeue();
                    var currentLock = locks.Peek();
                    var hasShoot = Shoot(locks, currentBullet, currentLock);
                    if (hasShoot == 1)
                    {
                        locks.Dequeue();
                    }
                    if (barrel.Count == 0)
                    {
                        if (bullets.Count > 0)
                        {

                            Console.WriteLine("Reloading!");
                        }
                    }
                    if (!locks.Any())
                    {
                        PrintSuccess(bulletsCount, bulletCounter, intelligence, priceForBullet);
                    }
                    i--;
                }
                if (!bullets.Any())
                {
                    PrintFaild(locks.Count);
                }

                

                barrel = new Queue<int>();
            }



        }

        private static void PrintFaild(int locksCount)
        {
            Console.WriteLine($"Couldn't get through. Locks left: {locksCount}");
            Environment.Exit(0);
        }

        private static void PrintSuccess(int bulletsCount, int bulletCounter, int intelligence, int priceforBullet)
        {
            var bulletsLeft = bulletsCount - bulletCounter;
            var money = intelligence - (bulletCounter * priceforBullet);
            Console.WriteLine($"{bulletsLeft} bullets left. Earned ${money}");
            Environment.Exit(0);
        }

        private static int Shoot(Queue<int> locks, int currentBullet, int currentLock)
        {
            if (currentBullet > currentLock)
            {
                Console.WriteLine("Ping!");
                return 0;
            }

            Console.WriteLine("Bang!");
            return 1;
        }
    }
}
