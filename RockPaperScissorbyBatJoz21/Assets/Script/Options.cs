using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;
    [SerializeField] Toggle muteToggle;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] TMP_Text bgmVolText;
    [SerializeField] TMP_Text sfxVolText;

    void Start()
    {
        muteToggle.isOn = audioManager.IsMute;
        bgmSlider.value = audioManager.BgmVolume;
        sfxSlider.value = audioManager.SfxVolume;
        SetBgmVolText(bgmSlider.value);
        SetSfxVolText(sfxSlider.value);
    }

    public void SetBgmVolText(float v)
    {
        bgmVolText.text = Mathf.RoundToInt(bgmSlider.value * 100).ToString();
    }

    public void SetSfxVolText(float v)
    {
        sfxVolText.text = Mathf.RoundToInt(sfxSlider.value * 100).ToString();
    }
}
