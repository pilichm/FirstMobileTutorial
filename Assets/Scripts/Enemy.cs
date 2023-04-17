using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 1.0f;
    private float xMoveBoundary = -4.0f;

    private Vector3 startPosition;

    private bool isMoving;
    private int maxMovementDelay = 3;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        isMoving = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        
        /**
         * Destroy enemy when it has left the screen.
         **/
        if (transform.position.x < xMoveBoundary)
        {
            ResetPosition();
        }
    }

    public void ResetPosition()
    {
        transform.position = startPosition;
        isMoving = false;
        StartCoroutine(WaitBeforeRestartMovement());
    }

    public void addValueToSpeed(float valueToAdd)
    {
        speed += valueToAdd;
    }

    IEnumerator WaitBeforeRestartMovement()
    {
        int movementDelay = Random.Range(0, maxMovementDelay);
        yield return new WaitForSeconds(movementDelay);
        isMoving = true;
    }
}
