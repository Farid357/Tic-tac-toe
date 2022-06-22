using UnityEngine;

public sealed partial class WinFinder : MonoBehaviour
{
    [SerializeField] private WinView _win;
    [SerializeField] private GridBuilder _grid;
    private bool _isWin;

    private void OnEnable() => _grid.OnUpdated += Check;

    private void OnDestroy() => _grid.OnUpdated -= Check;

    private void Check(Cell[,] cells)
    {
        CheckHorizontal(cells);
        CheckFirstDiagonal(cells);
        CheckSecondDiagonal(cells);
        CheckVertical(cells);
        CheckTie(cells);
    }

    private void CheckVertical(Cell[,] cells)
    {
        for (int layer = 0; layer < cells.GetLength(0); layer++)
        {
            CheckVerticalByState(cells, layer, State.Cross);
            CheckVerticalByState(cells, layer, State.Nought);
        }
    }

    private void CheckVerticalByState(Cell[,] cells, int layer, State state)
    {
        if (cells[layer, 0].State == state && cells[layer, 1].State == state)
        {
            if (cells[layer, 2].State == state)
            {
                Win(state);
            }
        }
    }

    private void CheckHorizontal(Cell[,] cells)
    {
        for (int layer = 0; layer < cells.GetLength(0); layer++)
        {
            CheckHorizontalByState(cells, layer, State.Cross);
            CheckHorizontalByState(cells, layer, State.Nought);
        }
    }

    private void CheckHorizontalByState(Cell[,] cells, int layer, State state)
    {
        if (cells[0, layer].State == state && cells[1, layer].State == state)
        {
            if (cells[2, layer].State == state)
            {
                Win(state);
            }
        }
    }

    private void ShowWinByState(State state)
    {
        if (state == State.Nought)
            _win.ShowNoughtWin();
        if (state == State.Cross)
            _win.ShowCrossWin();
    }
    private void Win(State state)
    {
        if (!_isWin)
        {
            _isWin = true;
            ShowWinByState(state);
        }
    }
}
