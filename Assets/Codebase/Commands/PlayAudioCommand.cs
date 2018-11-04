using Core;
using UnityEngine;

public class PlayAudioCommand : ICommand
{
    private AudioClip _clip;
    private Vector3 _position;

    public PlayAudioCommand(AudioClip clip, Vector3 position)
    {
        _position = position;
        _clip = clip;
    }

    public void Execute()
    {
        AudioSource.PlayClipAtPoint(_clip, _position);
    }
}