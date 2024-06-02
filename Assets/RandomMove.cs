using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    //https://forum.unity.com/threads/random-movement-for-enemies.1422570
    public float speed;
    private float minTime = 1f; 
    private float maxTime = 5f;
    private Vector3 origin;
    private Vector3 direction;
    private float timer;

    private float xRange = 1.5f;
    private float yRange = 0.5f;
    private float zRange = 1.5f;

    private void Start()
    {
        direction = UnityEngine.Random.insideUnitSphere;
        origin = transform.position;
        timer = UnityEngine.Random.Range(minTime, maxTime);
    }
    private void Update()
    {
        // Move the enemy in the current direction
        transform.Translate(direction * speed * Time.deltaTime);
        timer -= Time.deltaTime;
        if (math.abs(origin.x - transform.position.x) > xRange || math.abs(origin.x - transform.position.x) < -xRange) direction = -direction;
        if (math.abs(origin.y - transform.position.y) > yRange || math.abs(origin.y - transform.position.y) < -yRange) direction = -direction;
        if (math.abs(origin.z - transform.position.z) > zRange || math.abs(origin.z - transform.position.z) < -zRange) direction = -direction;

        if (timer <= 0f)
        {
            // Generate a new random direction
            direction = UnityEngine.Random.insideUnitSphere;
            timer = UnityEngine.Random.Range(minTime, maxTime);
        }
    }
}
