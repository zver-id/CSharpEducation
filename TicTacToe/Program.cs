using System;
using System.Collections.Generic;

namespace TicTacToe;

class Program
{
    static void Main(string[] args)
    {
        Board board = new Board();
        Player playerX = new Player("X");
        Player playerO = new Player("O");
        Player currentPlayer = playerX;
        Player inActivePlayer = playerO;
        Console.WriteLine("Привет! Я хочу поиграть с тобой в одну игру");
        while (true)
        {
            board.DrawBoard();
            Console.WriteLine("Введи номер ячейки");
            string input = Console.ReadLine();
            if (board.InputIsValid(input, out int position))
            {
                board.SetMark(position, currentPlayer.Mark);
                inActivePlayer.RemoveWinCombination(input);
            }
            else
            {
                Console.WriteLine("Вы ввели что-то не то");
            }
            
            if (currentPlayer.IsWin(board))
            {
                Console.WriteLine($"Игрок {currentPlayer.Mark} выиграл!");
                board.DrawBoard();
                break;
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
