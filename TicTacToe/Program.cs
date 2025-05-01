using System;

namespace TicTacToe;

class Program
{
    static void Main(string[] args)
    {
        var game = new Board();
        while (true)
        {
            game.DrawBoard();
            Console.WriteLine("Введите номер ячейки");
            var input = Console.ReadLine();
            if (game.InputIsValid(input, out var position))
            {
                game.SetMark(position, "X");
            }
            else
            {
                Console.WriteLine("Вы ввели что-то не то");
            }
        }
    }
}
