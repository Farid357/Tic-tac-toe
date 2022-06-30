using System;

public sealed class WinFinderOrder : IDisposable
{
    private readonly Field _field;
    private readonly Shape[] _shapes;
    private WinFinder[] _finders;

    public WinFinderOrder(Field field, Shape[] shapes)
    {
        _field = field ?? throw new ArgumentNullException(nameof(field));
        _shapes = shapes ?? throw new ArgumentNullException(nameof(shapes));
        _field.OnUpdated += Check;
    }

    public bool HasWon { get; private set; }

    public event Action<Shape> OnWon;

    public event Action OnGotTie;

    private void Check(IReadonlyCell[,] cells)
    {
        _finders = new WinFinder[]
        {
            new HorizonatalWinFinder(cells),
            new VerticalWinFinder(cells),
            new FirstDiagonalWinFinder(cells),
            new SecondDiagonalWinFinder(cells)
        };

        if (HasWon == false)
        {
            for (int i = 0; i < _shapes.Length; i++)
            {
                foreach (var finder in _finders)
                {
                    if (finder.TryCheckByShape(_shapes[i]))
                    {
                        HasWon = true;
                        OnWon?.Invoke(_shapes[i]);
                        break;
                    }
                }
            }

            if (_finders[0].TryCheckByNull())
            {
                OnGotTie?.Invoke();
            }
        }
    }

    public void Dispose() => _field.OnUpdated -= Check;
}
