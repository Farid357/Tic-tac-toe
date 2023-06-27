using System;
using UnityEngine;

public sealed class Field
{

    private readonly Vector3 _startPoint;
    private readonly Cell _prefab;
    private readonly Cell[,] _cells = new Cell[3, 3];
    private const float Cofficient = 0.2f;

    public Field(Cell prefab, Vector3 startPoint)
    {
        _startPoint = startPoint;
        _prefab = prefab ?? throw new ArgumentNullException(nameof(prefab));
        var offset = _prefab.GetComponent<SpriteRenderer>().bounds.size;
        Create(offset.x + Cofficient, offset.y + Cofficient);
    }

    public event Action<IReadonlyCell[,]> OnUpdated;

    public void SetState(IReadonlyCell readonlyCell, Shape shape)
    {
        var cell = readonlyCell as Cell;

        for (int x = 0; x < _cells.GetLength(0); x++)
        {
            for (int y = 0; y < _cells.GetLength(1); y++)
            {
                if (_cells[x, y].gameObject.name == cell.gameObject.name)
                {
                    _cells[x, y].SetShape(shape);
                    OnUpdated.Invoke(_cells);
                    break;
                }
            }
        }
    }


    private void Create(float xOffset, float yOffset)
    {
        var startPositionX = _startPoint.x;
        var startPositionY = _startPoint.y;

        for (int x = 0; x < _cells.GetLength(0); x++)
        {
            for (int y = 0; y < _cells.GetLength(1); y++)
            {
                var position = new Vector2(startPositionX + (xOffset * x), startPositionY + (yOffset * y));
                var cell = UnityEngine.Object.Instantiate(_prefab, position, Quaternion.identity);
                _cells[x, y] = cell;
                _cells[x, y].gameObject.name += $"{x} {y}";
            }
        }
    }
}
