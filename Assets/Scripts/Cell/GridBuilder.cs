using System;
using UnityEngine;

public sealed class GridBuilder : MonoBehaviour
{
    public event Action<Cell[,]> OnUpdated;
    [SerializeField] private Cell _prefab;
    private Cell[,] _cells = new Cell[3, 3];
    private const float Cofficient = 0.2f;

    public void SetState(Cell cell, State state)
    {
        for (int x = 0; x < _cells.GetLength(0); x++)
        {
            for (int y = 0; y < _cells.GetLength(1); y++)
            {
                if (_cells[x, y].gameObject.name == cell.gameObject.name)
                {
                    _cells[x, y].SetState(state);
                    OnUpdated.Invoke(_cells);
                    break;
                }
            }
        }
    }

    private void Awake()
    {
        var offset = _prefab.GetComponent<SpriteRenderer>().bounds.size;
        Create(offset.x + Cofficient, offset.y + Cofficient);
    }

    private void Create(float xOffset, float yOffset)
    {
        var startPositionX = transform.position.x;
        var startPositionY = transform.position.y;

        for (int x = 0; x < _cells.GetLength(0); x++)
        {
            for (int y = 0; y < _cells.GetLength(1); y++)
            {
                var position = new Vector2(startPositionX + (xOffset * x), startPositionY + (yOffset * y));
                var cell = Instantiate(_prefab, position, Quaternion.identity);
                _cells[x, y] = cell;
                _cells[x, y].gameObject.name += $"{x} {y}";
            }
        }
    }
}
