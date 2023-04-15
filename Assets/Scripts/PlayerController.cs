using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private float bottomVerticalMovementBoundary = -4.5f;
    private float topVerticalMovementBoundary = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("x: " + transform.position.x + " y: " + transform.position.y);

        /**
         * Move up when right arrow is pressed.
         **/
        if (Input.GetKey("right")) {
            Debug.Log("right.");
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        /**
         * Move down when left arrow is pressed. 
         **/
        if (Input.GetKey("left"))
        {
            Debug.Log("left.");
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        /**
         * Restrict player left and right movement. 
         **/
        if (transform.position.y > topVerticalMovementBoundary)
        {
            transform.position = new Vector2(transform.position.x, topVerticalMovementBoundary);
        }

        if (transform.position.y < bottomVerticalMovementBoundary)
        {
            transform.position = new Vector2(transform.position.x, bottomVerticalMovementBoundary);
        }

    }
}
