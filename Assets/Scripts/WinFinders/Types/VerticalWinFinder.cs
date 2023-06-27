using System.Collections.Generic;

public sealed class VerticalWinFinder : WinLayerFinder
{
    public VerticalWinFinder(IReadonlyCell[,] cells) : base(cells)
    {
    }

    protected override List<IReadonlyCell> GetVerticalCells(int x)
    {
        var cells = new List<IReadonlyCell>();
        for (int y = 0; y < Cells.GetLength(1); y++)
        {
            cells.Add(Cells[x, y]);
        }

        return cells;
    }
}

