using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioManager : MonoBehaviour
{
    public static UnityEvent<AudioClip> eventPlaySound = new UnityEvent<AudioClip>();

    [SerializeField] AudioSource myAudioSource;

    private void Awake()
    {
        if (myAudioSource == null)
        {
            Debug.LogError($"AudioManager: Awake: i have no reference to AudioSource");
            Destroy(this);
            return;
        }

        eventPlaySound.AddListener(PlaySound);
    }

    private void PlaySound(AudioClip audioClip)
    {
        myAudioSource.clip = audioClip;
        myAudioSource.Play();
    }
}
