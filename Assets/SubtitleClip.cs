using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


/*
 * Four scripts work together to create subtitles(SubtitleTrackMixer, SubtitleClip, SubtitleBehaviour, SubtitleTrack).
 * 
 * subtitleclip will be responsible for checking the player customization to see if the user has selected subtitles. 
 * If subtitles are selected, subtitlebehavior will be called at this point, and TMP information will be inserted here.
 * 
 * Based on the following YouTube video, these four scripts have been adapted and modified to meet the game's unique needs.
 * YT: https://www.youtube.com/watch?v=12bfRIvqLW4
 */

public class SubtitleClip : PlayableAsset
{
    public string subtitleText;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        if (!PlayerPrefs.HasKey("subtitle")) return new Playable();

        bool subtitle = PlayerPrefs.GetInt("subtitle") == 1;

        if (subtitle)
         {
            var playable = ScriptPlayable<SubtitleBehaviour>.Create(graph);

            SubtitleBehaviour subtitleBehaviour = playable.GetBehaviour();
            subtitleBehaviour.subtitleText = subtitleText;

            return playable;
         } else {
                return new Playable();
         }
    }
}
