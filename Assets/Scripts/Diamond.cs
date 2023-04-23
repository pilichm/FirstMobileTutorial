using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private float speed = 1.0f;
    private float xMoveBoundary = -4.0f;
    private float bottomVerticalMovementBoundary = -3.5f;
    private float topVerticalMovementBoundary = 3.5f;

    private GameManager gameManager;

    private Vector3 startPosition;

    private int maxMovementDelay = 15;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsStartedAndPlayerInPosition())
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            /**
            * Move diamond to start position enemy when it has left the screen.
            **/
            if (transform.position.x < xMoveBoundary)
            {
                ResetPosition();
            }
        }
    }

    public void ResetPosition()
    {
        transform.position = new Vector2(startPosition.x, Random.Range(bottomVerticalMovementBoundary, topVerticalMovementBoundary));
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
    }

    public void SubstractValueFromDelay(int valueToSubstract)
    {
        maxMovementDelay -= valueToSubstract;
    }
}
