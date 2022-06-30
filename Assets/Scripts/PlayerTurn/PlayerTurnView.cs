using UnityEngine;

public sealed class PlayerTurnView : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    private PlayerTurn _playerTurn;

    public void Init(PlayerTurn playerTurn)
    {
        _playerTurn = playerTurn ?? throw new System.ArgumentNullException(nameof(playerTurn));
        _playerTurn.OnChanged += Draw;
    }

    private void OnDisable() => _playerTurn.OnChanged -= Draw;

    private void Draw(Shape shape, Vector3 position)
    {
        Instantiate(shape, position, Quaternion.identity, _parent);
    }
}
