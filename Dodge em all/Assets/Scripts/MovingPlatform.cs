using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //---Position of the markers objects in scene
    public Transform position1;
    public Transform position2;

    [SerializeField] float moveSpeed = 3f;

    float dirX = 3f;
    bool moveRight = true;

    private void Update()
    {
        //---Based on the position of the markers in the game, decides to move right or left
        if (transform.position.x > position2.position.x)
        {
            moveRight = false;
        }
        if (transform.position.x < position1.position.x)
        {
            moveRight = true;
        }

        //---move platform to right until meeting the marker limit
        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        { //---move left according to the marker
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }
}
