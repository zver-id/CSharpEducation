using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe;

public class Player
{
    public Player(string mark)
    {
        if (mark == "X" || mark == "O")
            Mark = mark;
        else
            throw new ArgumentException("Неверное значение метки");
        
        WinCombinations = new List<string[]>
        {
            new string[] { "1", "2", "3" },
            new string[] { "4", "5", "6" },
            new string[] { "7", "8", "9" },
            new string[] { "1", "4", "7" },
            new string[] { "2", "5", "8" },
            new string[] { "3", "6", "9" },
            new string[] { "1", "5", "9" },
            new string[] { "3", "5", "7" }
        };
    }
    public string Mark { get; }
    private List<string[]> WinCombinations {get; set;}

    public void RemoveWinCombination(string position)
    {
        for (int i = 0; i < WinCombinations.Count; i++)
        {
            if (WinCombinations[i].Contains(position))
            {
                WinCombinations.RemoveAt(i);
                i--;
            }
        }
    }

    public bool CanWin()
    {
        return WinCombinations.Count > 0;
    }

    public bool IsWin(Board board)
    {
        foreach (var winCombination in WinCombinations)
        {
            for(int i = 0; i < winCombination.Length; i++)
            {
                var currentCell = board.GetCellValue(int.Parse(winCombination[i]));
                if(board.GetCellValue(int.Parse(winCombination[i])) != Mark) break;
                if (i == winCombination.Length - 1) return true;
            }
        }
        return false;
    }
}