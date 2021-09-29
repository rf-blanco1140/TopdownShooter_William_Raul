using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private GameObject _soundToggleBtn;
    private Text _btnText;
    private bool _isOn;

    private void Start()
    {
        _btnText = _soundToggleBtn.GetComponentInChildren<Text>();
        _btnText.text = "ON";
        _isOn = true;
    }

    public void ToggleOnOff()
    {
        switch(_isOn)
        {
            case true:
                _isOn = false;
                _btnText.text = "OFF";
                break;
            case false:
                _isOn = true;
                _btnText.text = "ON";
                break;
        }
    }
}
