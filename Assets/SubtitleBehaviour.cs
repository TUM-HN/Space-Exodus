using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

/*
 * Four scripts work together to create subtitles(SubtitleTrackMixer, SubtitleClip, SubtitleBehaviour, SubtitleTrack).
 * 
 * Subtitle behavior overrides process frame, enabling the processing of text on a specific canvas 
 * and generating corresponding slides projected onto the canvas.
 * 
 * Based on the following YouTube video, these four scripts have been adapted and modified to meet the game's unique needs.
 * YT: https://www.youtube.com/watch?v=12bfRIvqLW4
 */

public class SubtitleBehaviour : PlayableBehaviour
{
    public string subtitleText;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        TextMeshProUGUI text = playerData as TextMeshProUGUI;
        text.text = subtitleText;
        text.color = new Color(1, 1, 1, info.weight);

    }


}
