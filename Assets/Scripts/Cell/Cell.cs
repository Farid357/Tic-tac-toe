using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public sealed class Cell : MonoBehaviour
{
    public State State => _state;
    public static event Action<Cell> OnClicked;
    private State _state = State.None;
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        _audioSource.PlayOneShot(_audioSource.clip);
        OnClicked?.Invoke(this);
    }

    public void SetState(State state)
    {
        _state = state;
    }
   
}
public enum State
{
    None,
    Cross,
    Nought
}
