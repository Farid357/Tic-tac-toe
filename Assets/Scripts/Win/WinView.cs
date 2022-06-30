using UnityEngine;
using TMPro;

public sealed class WinView : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private Animation _winPanelAppearance;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private TextMeshProUGUI _text;
    private WinFinderOrder _win;

    public void Init(WinFinderOrder win)
    {
        _win = win ?? throw new System.ArgumentNullException(nameof(win));
        _win.OnWon += Show;
        _win.OnGotTie += ShowTie;
    }

    private void OnDisable()
    {
        _win.OnWon -= Show;
        _win.OnGotTie -= ShowTie;
    }

    private void Show(Shape shape)
    {
        ShowPanel();
        _text.text = $"{shape.gameObject.name} wins!";
        _text.gameObject.SetActive(true);
    }

    private void ShowTie()
    {
        ShowPanel();
        _text.text = "Tie";
        _text.gameObject.SetActive(true);
    }


    private void ShowPanel()
    {
        _audio.Play();
        _winPanelAppearance.Play();
        _winPanel.gameObject.SetActive(true);
    }
}
