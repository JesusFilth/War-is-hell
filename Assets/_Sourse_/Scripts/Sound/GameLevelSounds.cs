using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelSounds : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [Space]
    [SerializeField] private AudioClip _gold;

    public void PlayGold()
    {
        _audioSource.clip = _gold;
        _audioSource.Play();
    }
}
