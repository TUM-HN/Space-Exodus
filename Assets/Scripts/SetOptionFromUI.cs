using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class SetOptionFromUI : MonoBehaviour
{
    public Scrollbar volumeSlider;
    public TMPro.TMP_Dropdown turnDropdown;
    public SetTurnTypeFromPlayerPref turnTypeFromPlayerPref;
    public Toggle subtitleCheckBox;

    private void Start()
    {
        subtitleCheckBox.onValueChanged.AddListener(SetSubtitlePref);
        volumeSlider.onValueChanged.AddListener(SetGlobalVolume);
        turnDropdown.onValueChanged.AddListener(SetTurnPlayerPref);

        if (PlayerPrefs.HasKey("turn"))
            turnDropdown.SetValueWithoutNotify(PlayerPrefs.GetInt("turn"));

        if (PlayerPrefs.HasKey("subtitle"))
            subtitleCheckBox.SetIsOnWithoutNotify(PlayerPrefs.GetInt("subtitle") == 1);
    }

    public void SetGlobalVolume(float value)
    {
        AudioListener.volume = value;
    }

    public void SetTurnPlayerPref(int value)
    {
        PlayerPrefs.SetInt("turn", value); 
        turnTypeFromPlayerPref.ApplyPlayerPref();
    }

    public void SetSubtitlePref(bool value)
    {
        PlayerPrefs.SetInt("subtitle", value? 1 : 0);
    }
}
