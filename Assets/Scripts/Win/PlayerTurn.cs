using UnityEngine;

public sealed class PlayerTurn : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    [SerializeField] private GridBuilder _grid;
    [SerializeField] private GameObject _cross;
    [SerializeField] private GameObject _nought;
    private int _turn;

    private void OnEnable()
    {
        Cell.OnClicked += SetTurn;
    }

    private void OnDisable()
    {
        Cell.OnClicked -= SetTurn;
    }

    private void SetTurn(Cell cell)
    {

        if (cell.State == State.None)
        {
            if (_turn == 0)
            {
                _turn++;
                ShowCross(cell);
            }

            else if (_turn == 1)
            {
                _turn = 0;
                ShowNought(cell);
            }
        }
    }

    private void ShowCross(Cell cell)
    {
        Instantiate(_cross, cell.transform.position, Quaternion.identity, _parent);
        _grid.SetState(cell, State.Cross);
    }

    private void ShowNought(Cell cell)
    {
        Instantiate(_nought, cell.transform.position, Quaternion.identity, _parent);
        _grid.SetState(cell, State.Nought);
    }
}
