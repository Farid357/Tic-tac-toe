using System.Collections.Generic;
using UnityEngine;

public sealed class Root : MonoBehaviour
{
    [SerializeField] private PhysicsInput _input;
    [SerializeField] private Shape[] _shapes;
    [SerializeField] private Cell _prefab;
    [SerializeField] private Transform _spawnStartPoint;
    [SerializeField] private WinView _winView;
    [SerializeField] private PlayerTurnView _playerTurnView;
    private readonly List<IDisposable> _disposables = new();

    private void Start()
    {
        var field = new Field(_prefab, _spawnStartPoint.position);
        IDisposable player = new PlayerTurn(_input, _shapes, field);
        IDisposable win = new WinFinderOrder(field, _shapes);
        _winView.Init(win as WinFinderOrder);
        _input.Init(win as WinFinderOrder);
        _playerTurnView.Init(player as PlayerTurn);
        _disposables.Add(player);
        _disposables.Add(win);
    }

    private void OnDestroy()
    {
        _disposables.ForEach(disposable => disposable.Dispose());
    }
}
