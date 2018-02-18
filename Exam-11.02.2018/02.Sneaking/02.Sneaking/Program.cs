using System;
using System.Collections.Generic;
using System.Linq;

public class Program
    {
        private static int Rows = 0;
        private static char[][] Board;
        private static int NikoladzeRow = 0;
        private static int NikolafzeCol = 0;
        private static int SamRow = 0;
        private static int SamCol = 0;
        private static List<int> EnemiesRows = new List<int>();
        private static List<int> EnemiesCols = new List<int>();
        static void Main(string[] args)
        {
            Rows = int.Parse(Console.ReadLine());
            Board = new char[Rows][];
            ReadBoard();
            var moves = Console.ReadLine().ToCharArray();

            FindNikoladze();
            FindSam();
            MovePlayers(moves);

        }

        private static void FindSam()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Board[row].Length; col++)
                {
                    if (Board[row][col] == 'S')
                    {
                        SamRow = row;
                        SamCol = col;
                        return;
                    }
                }
            }
        }

        private static void FindNikoladze()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Board[row].Length; col++)
                {
                    if (Board[row][col] == 'N')
                    {
                        NikoladzeRow = row;
                        NikolafzeCol = col;
                        return;
                    }
                }
            }
        }

        private static void MovePlayers(char[] moves)
        {
            for (int turn = 0; turn < moves.Length; turn++)
            {
                EnemiesRows = new List<int>();
                EnemiesCols = new List<int>();
                MoveEnemies();
                MoveSam(moves[turn]);
                CheckNikoladzeAlive();
            }
        }

        private static void MoveSam(char direction)
        {
            if (direction == 'U')
            {
                Board[SamRow][SamCol] = '.';
                SamRow--;
                if (Board[SamRow][SamCol] == 'd' || Board[SamRow][SamCol] == 'b')
                {
                    EnemiesRows.Distinct();
                    EnemiesRows.Remove(SamRow);
                }
                Board[SamRow][SamCol] = 'S';
            }
            if (direction == 'D')
            {
                Board[SamRow][SamCol] = '.';
                SamRow++;
                if (Board[SamRow][SamCol] == 'd' || Board[SamRow][SamCol] == 'b')
                {
                    EnemiesRows.Distinct();
                    EnemiesRows.Remove(SamRow);
                }
                Board[SamRow][SamCol] = 'S';
            }
            if (direction == 'L')
            {
                Board[SamRow][SamCol] = '.';
                SamCol--;
                Board[SamRow][SamCol] = 'S';
            }
            if (direction == 'R')
            {
                Board[SamRow][SamCol] = '.';
                SamCol++;
                Board[SamRow][SamCol] = 'S';
            }
        }

        private static void CheckNikoladzeAlive()
        {
            if (SamRow == NikoladzeRow)
            {
                Board[NikoladzeRow][NikolafzeCol] = 'X';
                Console.WriteLine($"Nikoladze killed!");
                PrintBoard();
                Environment.Exit(0);
            }
        }

        private static void CheckAlive()
        {
            for (int row = 0; row < EnemiesRows.Count; row++)
            {
                if (EnemiesRows[row] == SamRow)
                {
                    if (EnemiesCols[row] < SamCol && Board[EnemiesRows[row]][EnemiesCols[row]] == 'b')
                    {
                        Console.WriteLine($"Sam died at {SamRow}, {SamCol}");
                        Board[SamRow][SamCol] = 'X';
                        PrintBoard();
                        Environment.Exit(0);
                    }
                    else if (EnemiesCols[row] > SamCol && Board[EnemiesRows[row]][EnemiesCols[row]] == 'd')
                    {
                        Console.WriteLine($"Sam died at {SamRow}, {SamCol}");
                        Board[SamRow][SamCol] = 'X';
                        PrintBoard();
                        Environment.Exit(0);
                    }
                }
            }
        }

        private static void PrintBoard()
        {
            for (int row = 0; row < Rows; row++)
            {
                Console.WriteLine(string.Join("", Board[row]));
            }
            Environment.Exit(0);
        }


        private static void MoveEnemies()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Board[row].Length; col++)
                {
                    if (Board[row][col] == 'b')
                    {
                        EnemiesRows.Add(row);
                        if (col < Board[row].Length - 1)
                        {
                            Board[row][col] = '.';
                            Board[row][++col] = 'b';
                            EnemiesCols.Add(col);
                        }
                        else
                        {
                            Board[row][col] = 'd';
                            EnemiesCols.Add(col);
                        }
                    }
                    else if (Board[row][col] == 'd')
                    {
                        EnemiesRows.Add(row);
                        if (col > 0)
                        {
                            Board[row][col] = '.';
                            Board[row][col - 1] = 'd';
                            EnemiesCols.Add(--col);
                        }
                        else
                        {
                            Board[row][col] = 'b';
                            EnemiesCols.Add(col);
                        }
                    }
                }
            }
            CheckAlive();
        }

        private static void ReadBoard()
        {
            for (int i = 0; i < Rows; i++)
            {
                var row = Console.ReadLine().ToCharArray();
                Board[i] = row;
            }
        }
    }
