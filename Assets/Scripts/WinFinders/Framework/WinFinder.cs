using System.Collections.Generic;
using System.Linq;

public abstract class WinFinder
{
    private readonly IReadonlyCell[,] _cells;

    public WinFinder(IReadonlyCell[,] cells)
    {
        _cells = cells ?? throw new System.ArgumentNullException(nameof(cells));
    }
    protected IReadonlyCell[,] Cells => _cells;

    public bool TryCheckByNull()
    {
        var cells = GetCells();
        return cells.All(cell => cell.Shape != null);
    }

    public abstract bool TryCheckByShape(Shape shape);

    private IEnumerable<IReadonlyCell> GetCells()
    {
        for (int x = 0; x < _cells.GetLength(0); x++)
        {
            for (int y = 0; y < _cells.GetLength(1); y++)
            {
                yield return _cells[x, y];
            }
        }
    }
}
