using System;

namespace TicTacToe;

public class Board
{
    string[,] board = {{"1", "2", "3"}, {"4", "5", "6"}, {"7", "8", "9"}};
    
    private int[] LastXMove { get; set;} = new int[] {-1, -1};
    private int[] LastOMove { get; set;}  = new int[] {-1, -1};
    public void DrawBoard()
    {
        ConsoleColor originalColor = Console.ForegroundColor;
        Console.WriteLine("_____________");
        for (var i = 0; i < 3; i++)
        {
            Console.Write("| ");
            for (var j = 0; j < 3; j++)
            {
                if (i == LastXMove[0] && j == LastXMove[1]) 
                    Console.ForegroundColor = ConsoleColor.Blue;
                if (i == LastOMove[0] && j == LastOMove[1])
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(board[i, j]);
                Console.ForegroundColor = originalColor;
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
        if (mark == "X") LastXMove = new int[] {row, positionInRow};
        else LastOMove = new int[] {row, positionInRow};
    }

    public string GetCellValue(int position)
    {
        var row = (position - 1) / 3;
        var positionInRow = position - 1 - row * 3;
        return board[row, positionInRow];
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