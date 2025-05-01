using System;

namespace TicTacToe;

class Program
{
    static void Main(string[] args)
    {
        var game = new Board();
        game.DrawBoard();
    }
}

class Board
{
    char[,] board = {{'1', '2', '3'}, {'4', '5', '6'}, {'7', '8', '9'}};

    public void DrawBoard()
    {
        Console.WriteLine("_____________");
        for (var i = 0; i < 3; i++)
        {
            Console.Write("| ");
            for (var j = 0; j < 3; j++)
            {
                Console.Write(board[i, j]);
                Console.Write(" | ");
            }
            Console.Write("\n\r");
            Console.WriteLine("_____________");
        }
    }
    
}