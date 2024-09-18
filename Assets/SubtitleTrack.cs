using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

/*
 * Four scripts work together to create subtitles(SubtitleTrackMixer, SubtitleClip, SubtitleBehaviour, SubtitleTrack).
 * 
 * SubtitleTrack, using clip and TMP, generates text and frames to overlay on the video. 
 * This allows for the addition of new subtitle tracks to the timeline, with precise timing control.
 * 
 * Based on the following YouTube video, these four scripts have been adapted and modified to meet the game's unique needs.
 * YT: https://www.youtube.com/watch?v=12bfRIvqLW4
 */

[TrackBindingType(typeof(TextMeshProUGUI))]
[TrackClipType(typeof(SubtitleClip))]
public class SubtitleTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<SubtitleTrackMixer>.Create(graph, inputCount);
    }
}
