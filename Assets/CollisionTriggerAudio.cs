using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script handles audio playback for collision events. 
 * Three audio listeners are initialized to differentiate between collisions involving bricks, windows, and the ground. 
 * Collision detection is achieved by examining the tag of the collided GameObject.
 * 
 * AudioClip can be customised here: https://pixabay.com/sound-effects/search/brick/
 */

public class CollisionTriggerAudio : MonoBehaviour
{

    public AudioClip CollisionWithBrick;
    public AudioClip CollisionWithWall;
    public AudioClip CollisionWithWindow;

    private AudioSource m_CollisionWithBrick;
    private AudioSource m_CollisionWithWall;
    private AudioSource m_CollisionWithWindow;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Brick") m_CollisionWithBrick = SetupAudioSource(CollisionWithBrick);
        if (collision.gameObject.tag == "Window") m_CollisionWithWindow = SetupAudioSource(CollisionWithWindow);
        if (collision.gameObject.tag == "Wall") m_CollisionWithWall = SetupAudioSource(CollisionWithWall);
    }


    private AudioSource SetupAudioSource(AudioClip clip) {
        // create the new audio source component on the game object and set up its properties
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = 2;
        source.loop = false;

        // start the clip from a random point
        source.time = clip.length;
        source.Play();
        source.minDistance = 1;
        source.maxDistance = 3;
        source.dopplerLevel = 1;
        return source;
    }
}
