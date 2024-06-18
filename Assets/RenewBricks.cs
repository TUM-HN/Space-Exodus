using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenewBricks : MonoBehaviour
{
    public List<GameObject> bricks;
    private Vector3 origin;
    private GameObject brick;


    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        GenerateNewBrick();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(origin, brick.transform.position);
        if (distance >= 0.5) GenerateNewBrick();
    }

    private void GenerateNewBrick() {
        int brickNumber = UnityEngine.Random.Range(0, bricks.Count - 1);
        GameObject newBrick = GameObject.Instantiate(bricks[brickNumber], transform.position, transform.rotation);
        brick = newBrick;
    }
}
