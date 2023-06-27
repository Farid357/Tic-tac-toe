using System.Collections.Generic;
using System.Linq;

public abstract class WinLayerFinder : WinFinder
{
    public WinLayerFinder(IReadonlyCell[,] cells) : base(cells)
    {
    }


    public override bool TryCheckByShape(Shape shape)
    {
        bool verticalCheck = false;
        bool horizontalCheck = false;

        for (int i = 0; i < Cells.GetLength(0); i++)
        {
            var horizontalCells = GetHorizontalCells(i);
            var verticalCells = GetVerticalCells(i);
            horizontalCheck = horizontalCells != null && horizontalCells.All(cell => cell.Shape == shape);
            verticalCheck = verticalCells != null && verticalCells.All(cell => cell.Shape == shape);

            if (horizontalCheck || verticalCheck)
                break;
        }

        return horizontalCheck || verticalCheck;
    }


    protected virtual List<IReadonlyCell> GetHorizontalCells(int y) => null;

    protected virtual List<IReadonlyCell> GetVerticalCells(int x) => null;
}
