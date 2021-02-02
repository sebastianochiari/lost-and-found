using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneManager : MonoBehaviour
{

    public Vector3 startingV;

    public Vector3 endingV;

    public float speed = 2f;

    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        // AIRPLANE STARTING POSITION
        transform.position = startingV;
        
        // AIRPLANE ROTATION
        target = endingV;
        // vector that depicts the movement direction of the airplane
        var movementDirection = (target - transform.position);
        // z angle
        var angle = Vector2.Angle(Vector2.up, movementDirection);
        // set airplane rotation
        transform.Rotate(0, 0, angle);
    }

    // Update is called once per frame
    void Update()
    {

         // Move our position a step closer to the target.
        float step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target, step);

        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            Debug.Log("arrivato");
        }

    }
}
