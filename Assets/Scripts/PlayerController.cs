using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private float bottomVerticalMovementBoundary = -3.5f;
    private float topVerticalMovementBoundary = 3.5f;

    private GameManager gameManager;

    private int valueToSubstractOnCollisionWithEnemy = -10;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
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

    void OnTriggerEnter2D(Collider2D other)
    {
        /**
         * On collision with enemy substract value from player score and destroy enemy.
         **/
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Collision with enemy!");
            Destroy(other.gameObject);
            gameManager.AddValueToPlayerScore(valueToSubstractOnCollisionWithEnemy);
        } else
        {
            Debug.Log("Other collsion.!");
        }
    }

}
