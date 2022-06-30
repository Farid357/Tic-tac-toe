using UnityEngine;

public interface IReadonlyCell
{
    public Shape Shape { get; }
    public Vector3 Position { get; }
}