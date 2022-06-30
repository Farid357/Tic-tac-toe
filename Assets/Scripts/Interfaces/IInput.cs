using System;

public interface IInput
{
    public event Action<IReadonlyCell> OnInputed;
}