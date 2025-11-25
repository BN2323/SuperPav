using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip click, pav, playeWin, aiWin;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySfx(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
