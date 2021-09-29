using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private GameObject _musicToggleBtn;
    [SerializeField] private GameObject _sfxToggleBtn;
    private Text _musciBtnText;
    private Text _sfxBtnText;
    private bool _musicIsOn;
    private bool _sfxIsOn;
    [SerializeField] private AudioMixer _audioMixer;

    private void Start()
    {
        _musciBtnText = _musicToggleBtn.GetComponentInChildren<Text>();
        _musciBtnText.text = "ON";
        _sfxBtnText = _sfxToggleBtn.GetComponentInChildren<Text>();
        _sfxBtnText.text = "ON";
        _musicIsOn = true;
        _sfxIsOn = true;
    }

    public void ToggleMusicOnOff()
    {
        switch(_musicIsOn)
        {
            case true:
                _musicIsOn = false;
                _musciBtnText.text = "OFF";
                _audioMixer.SetFloat("musicVol", -80.0f);
                break;
            case false:
                _musicIsOn = true;
                _musciBtnText.text = "ON";
                _audioMixer.SetFloat("musicVol", 0f);
                break;
        }
    }

    public void ToggleSfxOnOff()
    {
        switch (_sfxIsOn)
        {
            case true:
                _sfxIsOn = false;
                _sfxBtnText.text = "OFF";
                _audioMixer.SetFloat("sfxVol",-80f);
                break;
            case false:
                _sfxIsOn = true;
                _sfxBtnText.text = "ON";
                _audioMixer.SetFloat("sfxVol", 0f);
                break;
        }
    }
}
