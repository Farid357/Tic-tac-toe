using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public sealed partial class WinFinder : MonoBehaviour
{
    private void CheckSecondDiagonalByState(Cell[,] cells, State state)
    {
        if (cells[0, 0].State == state && cells[1, 1].State == state)
        {
            if (cells[2, 2].State == state)
            {
                if (!_isWin)
                {
                    if (state == State.Cross)
                        _win.ShowCrossWin();
                    else
                        _win.ShowNoughtWin();
                }
            }
        }
    }

    private void CheckFirstDiagonalByState(Cell[,] cells, State state)
    {
        if (cells[0, 2].State == state && cells[1, 1].State == state)
        {
            if (cells[2, 0].State == state)
            {
                if (!_isWin)
                {
                    if (state == State.Cross)
                        _win.ShowCrossWin();
                    else
                        _win.ShowNoughtWin();
                }
            }
        }
    }

    private void CheckSecondDiagonal(Cell[,] cells)
    {
        CheckSecondDiagonalByState(cells, State.Cross);
        CheckSecondDiagonalByState(cells, State.Nought);
    }

    private void CheckFirstDiagonal(Cell[,] cells)
    {
        CheckFirstDiagonalByState(cells, State.Cross);
        CheckFirstDiagonalByState(cells, State.Nought);
    }
    private void CheckTie(Cell[,] cells)
    {
        List<Cell> cellsList = new();

        for (int x = 0; x < cells.GetLength(0); x++)
        {
            for (int y = 0; y < cells.GetLength(1); y++)
            {
                cellsList.Add(cells[x, y]);
            }
        }

        if (!_isWin)
        {
            if (cellsList.All(c => c.State != State.None))
                _win.ShowTie();
        }
    }
}
