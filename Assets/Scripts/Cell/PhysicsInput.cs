using UnityEngine;
using System;

public sealed class PhysicsInput : MonoBehaviour, IInput
{
    [SerializeField] private Camera _camera;
    private WinFinderOrder _win;

    public void Init(WinFinderOrder win)
    {
        _win = win ?? throw new ArgumentNullException(nameof(win));
    }

    private bool GameNotEnded => _win.HasWon == false;

    public event Action<IReadonlyCell> OnInputed;


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && GameNotEnded)
        {
            var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            var hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.transform.gameObject.TryGetComponent(out IReadonlyCell cell))
                {
                    OnInputed?.Invoke(cell);
                }
            }
        }
    }
}
