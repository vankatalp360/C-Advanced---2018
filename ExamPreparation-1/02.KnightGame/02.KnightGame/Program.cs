using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace _02.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var boardSize = int.Parse(Console.ReadLine());
            var board = new char[boardSize][];

            ReadBoard(boardSize, board);
            if (boardSize <= 3)
            {
                Console.WriteLine("0");
                Environment.Exit(0);
            }

            var knightRow = 0;
            var knightCol = 0;
            var maxAttacks = 0;
            var removeCount = 0;
            do
            {
                if (maxAttacks > 0)
                {
                    board[knightRow][knightCol] = '0';
                    maxAttacks = 0;
                    removeCount++;
                }

                for (int row = 0; row < boardSize; row++)
                {
                    for (int col = 0; col < boardSize; col++)
                    {
                        var currentAttacks = 0;
                        if (board[row][col] == 'K')
                        {
                            currentAttacks = CountAttaks(row, col, board);
                        }

                        if (currentAttacks > maxAttacks)
                        {
                            knightRow = row;
                            knightCol = col;
                            maxAttacks = currentAttacks;
                        }
                    }
                }

            } while (maxAttacks > 0);

            Console.WriteLine(removeCount);

        }

        private static int CountAttaks(int row, int col, char[][] board)
        {
            var currentAttacks = 0;

            currentAttacks += MoveUpDown(row, col, board);
            currentAttacks += MoveLeftRight(row, col, board);

            return currentAttacks;
        }

        private static int MoveUpDown(int row, int col, char[][] board)
        {
            var attaks = 0;
            if (row > 1)
            {
                if (col > 0)
                {
                    if (board[row - 2][col - 1] == 'K')
                    {
                        attaks++;
                    }
                }
                if (col < board[0].Length - 1)
                {
                    if (board[row - 2][col + 1] == 'K')
                    {
                        attaks++;
                    }
                }
            }
            if (row < board[0].Length - 2)
            {
                if (col > 0)
                {
                    if (board[row + 2][col - 1] == 'K')
                    {
                        attaks++;
                    }
                }
                if (col < board[0].Length - 1)
                {
                    if (board[row + 2][col + 1] == 'K')
                    {
                        attaks++;
                    }
                }
            }

            return attaks;
        }

        private static int MoveLeftRight(int row, int col, char[][] board)
        {
            var attaks = 0;
            if (col > 1)
            {
                if (row > 0)
                {
                    if (board[row - 1][col - 2] == 'K')
                    {
                        attaks++;
                    }
                }
                if (row < board[0].Length - 1)
                {
                    if (board[row + 1][col - 2] == 'K')
                    {
                        attaks++;
                    }
                }
            }
            if (col < board[0].Length - 2)
            {
                if (row > 0)
                {
                    if (board[row - 1][col + 2] == 'K')
                    {
                        attaks++;
                    }
                }
                if (row < board[0].Length - 1)
                {
                    if (board[row + 1][col + 2] == 'K')
                    {
                        attaks++;
                    }
                }
            }


            return attaks;
        }

        private static void ReadBoard(int boardSize, char[][] board)
        {
            for (int i = 0; i < boardSize; i++)
            {
                board[i] = Console.ReadLine().ToCharArray();
            }
        }
    }
}
