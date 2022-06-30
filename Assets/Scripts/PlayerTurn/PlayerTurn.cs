using System;
using UnityEngine;

public sealed class PlayerTurn : IDisposable
{
    private readonly IInput _input;
    private readonly Shape[] _shapes;
    private readonly Field _field;
    private int _turn;

    public event Action<Shape, Vector3> OnChanged;

    public PlayerTurn(IInput input, Shape[] shapes, Field field)
    {
        _field = field ?? throw new ArgumentNullException(nameof(field));
        _input = input ?? throw new ArgumentNullException(nameof(input));
        _shapes = shapes ?? throw new ArgumentNullException(nameof(shapes));
        _input.OnInputed += ChangeTurn;
    }

    private void ChangeTurn(IReadonlyCell cell)
    {
        _turn++;
        if (_turn > _shapes.Length - 1)
        {
            _turn = 0;
        }

        var shape = _shapes[_turn];
        _field.SetState(cell, shape);
        OnChanged?.Invoke(shape, cell.Position);
    }

    public void Dispose()
    {
        _input.OnInputed -= ChangeTurn;
    }
}
