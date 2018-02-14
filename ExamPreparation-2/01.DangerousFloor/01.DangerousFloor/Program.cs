using System;
using System.ComponentModel.Design;
using System.Linq;

namespace _01.DangerousFloor
{
    class Program
    {
        private static int BoardSize = 8;
        static void Main(string[] args)
        {
            var board = new char[8][];
            ReadBoard(board);

            ReadTurns(board);
        }

        private static void ReadTurns(char[][] board)
        {
            string line;

            while ((line = Console.ReadLine()) != "END")
            {
                var piece = char.Parse(line.Substring(0, 1));
                var positionRow = int.Parse(line.Substring(1, 1));
                var positionCol = int.Parse(line.Substring(2, 1));
                var finalRow = int.Parse(line.Substring(4, 1));
                var finalCol = int.Parse(line.Substring(5, 1));

                MovePiece(board, piece, positionRow, positionCol, finalRow, finalCol);
            }
        }

        private static void MovePiece(char[][] board, char piece, int positionRow, int positionCol, int finalRow, int finalCol)
        {
            var havePiece = ThereIsPiece(board, positionRow, positionCol);
            if (havePiece == false)
            {
                Console.WriteLine("There is no such a piece!");
                return;
            }
            CheckMove(board, piece, positionRow, positionCol, finalRow, finalCol);
        }

        private static void CheckMove(char[][] board, char piece, int positionRow, int positionCol, int finalRow, int finalCol)
        {
            var move = false;

            switch (piece)
            {
                case 'K': move = King(board, piece, positionRow, positionCol, finalRow, finalCol);
                    break;
                case 'R': move = Rook(board, piece, positionRow, positionCol, finalRow, finalCol);
                    break;
                case 'B': move = Bishop(board, piece, positionRow, positionCol, finalRow, finalCol);
                    break;
                case 'Q': move = Queen(board, piece, positionRow, positionCol, finalRow, finalCol);
                    break;
                case 'P': move = Pawn(board, piece, positionRow, positionCol, finalRow, finalCol);
                    break;
            }

            if (move == false)
            {
                Console.WriteLine("Invalid move!");
            }
        }

        private static bool Queen(char[][] board, char piece, int row, int col, int finalRow, int finalCol)
        {
            var onBoard = Onboard(finalRow, finalCol);
            var x = Math.Abs(finalRow - row);
            var y = Math.Abs(finalCol - col);
            if ((x == y && x > 0) ||
                (col == finalCol || row == finalRow))
            {
                if (onBoard == false)
                {
                    Console.WriteLine("Move go out of board!");
                    return true;
                }
                board[row][col] = 'x';
                board[finalRow][finalCol] = 'Q';
                return true;
            }
            return false;
        }

        private static bool Bishop(char[][] board, char piece, int row, int col, int finalRow, int finalCol)
        {
            var onBoard = Onboard(finalRow, finalCol);
            var x = Math.Abs(finalRow - row);
            var y = Math.Abs(finalCol - col);
            if (x == y && x > 0)
            {
                if (onBoard == false)
                {
                    Console.WriteLine("Move go out of board!");
                    return true;
                }
                board[row][col] = 'x';
                board[finalRow][finalCol] = 'B';
                return true;
            }
            return false;
        }

        private static bool King(char[][] board, char piece, int row, int col, int finalRow, int finalCol)
        {
            var onBoard = Onboard(finalRow, finalCol);
            if ((col == finalCol && row + 1 == finalRow || col == finalCol && row - 1 == finalRow)
                || (row == finalRow && col + 1 == finalCol || row == finalRow && col - 1 == finalCol)
                || (col - 1 == finalCol && row - 1 == finalRow || col + 1 == finalCol && row - 1 == finalRow)
                || (col - 1 == finalCol && row + 1 == finalRow || col + 1 == finalCol && row + 1 == finalRow))
            {
                if (onBoard == false)
                {
                    Console.WriteLine("Move go out of board!");
                    return true;
                }
                board[row][col] = 'x';
                board[finalRow][finalCol] = 'K';
                return true;
            }
            return false;
        }

        private static bool Rook(char[][] board, char piece, int row, int col, int finalRow, int finalCol)
        {
            var onBoard = Onboard(finalRow, finalCol);
            if (col == finalCol || row == finalRow)
            {
                if (onBoard == false)
                {
                    Console.WriteLine("Move go out of board!");
                    return true;
                }
                board[row][col] = 'x';
                board[finalRow][finalCol] = 'R';
                return true;
            }
            return false;
        }

        private static bool Pawn(char[][] board, char piece, int row, int col, int finalRow, int finalCol)
        {
            var onBoard = Onboard(finalRow, finalCol);
            if (col == finalCol && row - 1 == finalRow)
            {
                if (onBoard == false)
                {
                    Console.WriteLine("Move go out of board!");
                    return true;
                }
                board[row][col] = 'x';
                board[finalRow][finalCol] = 'P';
                return true;
            }
            return false;
        }

        private static bool Onboard(int finalRow, int finalCol)
        {
            if (finalRow >= 0 && finalRow < BoardSize
                && finalCol >= 0 && finalCol < BoardSize)
            {
                return true;
            }
            return false;
        }

        private static bool ThereIsPiece(char[][] board, int Row, int Col)
        {
            if (Row < 0 || Row >= BoardSize
                || Col < 0 || Col >= BoardSize)
            {
                return false;
            }
            if (board[Row][Col] != 'x')
            {
                return true;
            }
            return false;
        }

        private static void ReadBoard(char[][] board)
        {
            for (int row = 0; row < BoardSize; row++)
            {
                board[row] = Console.ReadLine()
                    .Split(new string[] {","}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
            }
        }
    }
}
