using System.Collections.Generic;

public sealed class SecondDiagonalWinFinder : WinDiagonalFinder
{
    public SecondDiagonalWinFinder(IReadonlyCell[,] cells) : base(cells)
    {

    }

    protected override List<IReadonlyCell> GetCells()
    {
        var cells = new List<IReadonlyCell>();

        for (int x = 0; x < Cells.GetLength(0); x++)
        {
            var j = x;
            cells.Add(Cells[x, j]);
        }

        return cells;
    }
}