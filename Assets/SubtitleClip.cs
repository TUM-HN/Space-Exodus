using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

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
