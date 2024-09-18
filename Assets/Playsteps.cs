using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

/*
 * PlayStep offers the possibility to play a timeline in segments. 
 * Through public serialized Step, you can save the desired time and chapters externally. 
 * When PlayStepIndex is called, it will play the corresponding segment of the timeline according to the index.
 * 
 * The code reference form the following yt video: https://www.youtube.com/watch?v=YBQ_ps6e71k
 */

public class Playsteps : MonoBehaviour
{
    PlayableDirector director;
    public List<Step> steps;

    // Start is called before the first frame update
    void Start()
    {
        director = GetComponent<PlayableDirector>();
    }

    [System.Serializable]

    public class Step {
        public string name;
        public float time;
        public bool hasPlayed = false;
    }

    public void PlayStepIndex(int index) {
        Step step = steps[index];

        if (!step.hasPlayed) {
            step.hasPlayed = true;

            director.Stop();
            director.time = step.time;
            director.Play();
        }
    }
}
