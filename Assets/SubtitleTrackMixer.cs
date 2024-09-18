using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

/*
 * Four scripts work together to create subtitles(SubtitleTrackMixer, SubtitleClip, SubtitleBehaviour, SubtitleTrack).
 * 
 * While subtitletrackmixer overlaps with subtitletrack, it offers a more granular control over text display. 
 * By adjusting the text input weight, it eliminates text when no narration is present, unlike subtitletrack. 
 * Furthermore, it integrates with a localization system to ensure that subtitles are displayed in the appropriate language 
 * based on the selected language setting.
 * 
 * Based on the following YouTube video, these four scripts have been adapted and modified to meet the game's unique needs.
 * YT: https://www.youtube.com/watch?v=12bfRIvqLW4
 */

[RequireComponent(typeof(TextMeshProUGUI))]
public class SubtitleTrackMixer : PlayableBehaviour
{
    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        TextMeshProUGUI text = playerData as TextMeshProUGUI;
        string currentText = "";
        float currentAlpha = 0f;

        if (!text) return;

        int inputCount = playable.GetInputCount();

        for (int i = 0; i < inputCount; i++) {

            float inputWeight = playable.GetInputWeight(i);

            if (inputWeight > 0f) {
                ScriptPlayable<SubtitleBehaviour> inputPlayable = (ScriptPlayable<SubtitleBehaviour>)playable.GetInput(i);

                SubtitleBehaviour input = inputPlayable.GetBehaviour();

                currentText = input.subtitleText;
                currentAlpha = inputWeight;
            }
        }

        string value = LocalisationSystem.GetLocalisedValue(currentText);

        if (String.IsNullOrEmpty(value)) {
            text.text = "NullorEmpty";
        }
        else {
            text.text = value;

        }

        text.color = new Color(1, 1, 1, currentAlpha);
    }
}
