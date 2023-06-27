using System.Collections.Generic;
using System.Linq;

public abstract class WinDiagonalFinder : WinFinder
{
    public WinDiagonalFinder(IReadonlyCell[,] cells) : base(cells)
    {

    }

    public override bool TryCheckByShape(Shape shape)
    {
        var cells = GetCells();
        var hasNotAnyEmpty = cells.Any(cell => cell.Shape == null) == false;

        if (hasNotAnyEmpty)
        {
            return cells.All(cell => cell.Shape == shape);
        }

        return false;
    }

    protected abstract List<IReadonlyCell> GetCells();

}
