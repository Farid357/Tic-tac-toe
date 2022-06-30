using System.Collections.Generic;

public sealed class HorizonatalWinFinder : WinLayerFinder
{
    public HorizonatalWinFinder(IReadonlyCell[,] cells) : base(cells)
    {
    }

    protected override List<IReadonlyCell> GetHorizontalCells(int y)
    {
        var cells = new List<IReadonlyCell>();

        for (int x = 0; x < Cells.GetLength(1); x++)
        {
            cells.Add(Cells[x, y]);
        }

        return cells;
    }
}