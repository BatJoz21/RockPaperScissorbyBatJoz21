using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioSource bgmInstance;
    static AudioSource moveSFXInstance;
    static AudioSource damageSFXInstance;
    static AudioSource deathSFXInstance;
    static AudioSource winSFXInstance;

    [SerializeField] AudioSource bgm;
    [SerializeField] AudioSource moveSfx;
    [SerializeField] AudioSource damageSfx;
    [SerializeField] AudioSource deathSfx;
    [SerializeField] AudioSource winSfx;

    public bool IsMute { get => bgm.mute; }
    public float BgmVolume { get => bgm.volume; }
    public float SfxVolume { get => moveSfx.volume; }

    private void Start()
    {
        if (bgmInstance != null)
        {
            Destroy(bgm.gameObject);
            bgm = bgmInstance;
        }
        else
        {
            bgmInstance = bgm;
            bgm.transform.SetParent(null);
            DontDestroyOnLoad(bgm.gameObject);
        }        

        if (moveSFXInstance != null)
        {
            Destroy(moveSfx.gameObject);
            moveSfx = moveSFXInstance;
        }
        else
        {
            moveSFXInstance = moveSfx;
            moveSfx.transform.SetParent(null);
            DontDestroyOnLoad(moveSfx.gameObject);
        }        

        if (damageSFXInstance != null)
        {
            Destroy(damageSfx.gameObject);
            damageSfx = damageSFXInstance;
        }
        else
        {
            damageSFXInstance = damageSfx;
            damageSfx.transform.SetParent(null);
            DontDestroyOnLoad(damageSfx.gameObject);
        }        

        if (deathSFXInstance != null)
        {
            Destroy(deathSfx.gameObject);
            deathSfx = deathSFXInstance;
        }
        else
        {
            deathSFXInstance = deathSfx;
            deathSfx.transform.SetParent(null);
            DontDestroyOnLoad(deathSfx.gameObject);
        }

        if (winSFXInstance != null)
        {
            Destroy(winSfx.gameObject);
            winSfx = winSFXInstance;
        }
        else
        {
            winSFXInstance = winSfx;
            winSfx.transform.SetParent(null);
            DontDestroyOnLoad(winSfx.gameObject);
        }
    }

    public void PlayBGM(AudioClip clip, bool loop = true)
    {
        if (bgm.isPlaying == true)
            bgm.clip = clip;

        bgm.loop = loop;
        bgm.Play();
    }

    public void PlayMoveSfx(AudioClip clip)
    {
        if (moveSfx.isPlaying == true)
            moveSfx.Stop();

        moveSfx.clip = clip;
        moveSfx.Play();
    }

    public void PlayDamageSFX(AudioClip clip)
    {
        if (damageSfx.isPlaying == true)
            damageSfx.Stop();

        damageSfx.clip = clip;
        damageSfx.Play();
    }

    public void PlayDeathSFX(AudioClip clip)
    {
        if (deathSfx.isPlaying == true)
            deathSfx.Stop();

        deathSfx.clip = clip;
        deathSfx.Play();
    }

    public void PlayWinSFX(AudioClip clip)
    {
        if (winSfx.isPlaying == true)
            winSfx.Stop();

        winSfx.clip = clip;
        winSfx.Play();
    }

    public void SetMute(bool v)
    {
        bgm.mute = v;
        moveSfx.mute = v;
        damageSfx.mute= v;
        deathSfx.mute= v;
        winSfx.mute = v;
    }

    public void SetVolumeBGM(float v)
    {
        bgm.volume = v;
    }

    public void SetVolumeSFX(float v)
    {
        moveSfx.volume = v;
        damageSfx.volume = v;
        deathSfx.volume = v;
        winSfx.volume = v;
    }
}
