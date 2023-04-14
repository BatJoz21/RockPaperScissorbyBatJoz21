using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource sfx;

    public void PlayBGM(AudioClip clip, bool loop = true)
    {
        if (bgm.isPlaying == true)
            bgm.clip = clip;

        bgm.loop = loop;
        bgm.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (sfx.isPlaying == true)
            sfx.Stop();

        sfx.clip = clip;
        sfx.Play();
    }
}
