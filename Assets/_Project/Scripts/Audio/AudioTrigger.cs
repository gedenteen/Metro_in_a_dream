using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    [SerializeField] private AudioClip myAudioClip;

    private void OnTriggerEnter(Collider other)
    {
        AudioManager.eventPlaySound.Invoke(myAudioClip);
    }
}
