using UnityEngine;
using TMPro;

public sealed class WinView : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private Animation _winPanelAppearance;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private TextMeshProUGUI _crossText;
    [SerializeField] private TextMeshProUGUI _noughtText;
    [SerializeField] private TextMeshProUGUI _tieText;

    public void ShowCrossWin()
    {
        Show();
        _crossText.gameObject.SetActive(true);
    }
    public void ShowTie()
    {
        Show();
        _tieText.gameObject.SetActive(true);
    }

    private void Show()
    {
        _audio.Play();
        _winPanelAppearance.Play();
        _winPanel.gameObject.SetActive(true);
    }

    public void ShowNoughtWin()
    {
        Show();
        _winPanel.gameObject.SetActive(true);
        _noughtText.gameObject.SetActive(true);
    }
}
