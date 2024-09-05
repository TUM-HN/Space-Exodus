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
    public TMPro.TMP_Dropdown languageDropdown;

    private void Start()
    {
        subtitleCheckBox.onValueChanged.AddListener(SetSubtitlePref);
        volumeSlider.onValueChanged.AddListener(SetGlobalVolume);
        turnDropdown.onValueChanged.AddListener(SetTurnPlayerPref);
        languageDropdown.onValueChanged.AddListener(SetLanguagePref);

        if (PlayerPrefs.HasKey("turn"))
            turnDropdown.SetValueWithoutNotify(PlayerPrefs.GetInt("turn"));

        if (PlayerPrefs.HasKey("subtitle"))
            subtitleCheckBox.SetIsOnWithoutNotify(PlayerPrefs.GetInt("subtitle") == 1);

        if (PlayerPrefs.HasKey("language"))
        {
            languageDropdown.SetValueWithoutNotify(PlayerPrefs.GetInt("language"));
        }
        else {
            LocalisationSystem.language = LocalisationSystem.Language.English;
        }
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

    public void SetLanguagePref(int value) {
        PlayerPrefs.SetInt("language", value);

        if (value == 0) {
            LocalisationSystem.language = LocalisationSystem.Language.English;
        }
        else
        {
            LocalisationSystem.language = LocalisationSystem.Language.Spanish;
        }
    }
}
