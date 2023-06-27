using System.Collections.Generic;

public sealed class FirstDiagonalWinFinder : WinDiagonalFinder
{
    public FirstDiagonalWinFinder(IReadonlyCell[,] cells) : base(cells)
    {

    }

    protected override List<IReadonlyCell> GetCells()
    {
        var cells = new List<IReadonlyCell>();

        var y = Cells.GetLength(1);
        for (int x = 0; x < Cells.GetLength(0); x++)
        {
            y--;
            cells.Add(Cells[x, y]);
        }

        return cells;
    }
}

