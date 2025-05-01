using System;

namespace TicTacToe;

class Program
{
    static void Main(string[] args)
    {
        var board = new Board();
        var playerX = new Player("X");
        var playerO = new Player("O");
        var currentPlayer = playerX;
        var inActivePlayer = playerO;
        Console.WriteLine("Привет! Я хочу поиграть с тобой в одну игру");
        while (true)
        {
            board.DrawBoard();
            Console.WriteLine("Введи номер ячейки");
            var input = Console.ReadLine();
            if (board.InputIsValid(input, out var position))
            {
                board.SetMark(position, currentPlayer.Mark);
                inActivePlayer.RemoveWinCombination(input);
            }
            else
            {
                Console.WriteLine("Вы ввели что-то не то");
            }

            if (!currentPlayer.CanWin() && !inActivePlayer.CanWin())
            {
                Console.WriteLine("Ничья, ёфай!");
                break;
            }
            SwapPlayers(ref currentPlayer, ref inActivePlayer);
        }
        Console.ReadLine();
    }
    public static void SwapPlayers(ref Player currentPlayer, ref Player inActivePlayer)
    {   
        (currentPlayer, inActivePlayer) = (inActivePlayer, currentPlayer);
    }
}
