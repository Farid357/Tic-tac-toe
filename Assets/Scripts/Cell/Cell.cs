using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource))]
public sealed class Cell : MonoBehaviour, IReadonlyCell
{
    private AudioSource _audioSource;

    public Shape Shape { get; private set; }

    public Vector3 Position => transform.position;

    private void Awake() => _audioSource = GetComponent<AudioSource>();

    public void SetShape(Shape shape)
    {
        Shape = shape ?? throw new ArgumentNullException(nameof(shape));
        _audioSource.PlayOneShot(_audioSource.clip);
    }
}
