using System;

namespace TicTacToe;

class Board
{
    string[,] board = {{"1", "2", "3"}, {"4", "5", "6"}, {"7", "8", "9"}};

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

    public void SetMark(int position, string mark)
    {
        var row = (position - 1) / 3;
        var positionInRow = position - 1 - row*3;
        board[row, positionInRow] = mark;
    }

    public bool InputIsValid(string numberOfCell, out int position)
    {
        if (int.TryParse(numberOfCell, out position))
        {
            foreach (var value in board)
            {
                if (value == numberOfCell)
                    return true;
            }
        }
        return false;
    }
}