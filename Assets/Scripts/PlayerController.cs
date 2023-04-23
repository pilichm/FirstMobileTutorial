using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private float bottomVerticalMovementBoundary = -3.5f;
    private float topVerticalMovementBoundary = 3.5f;

    private GameManager gameManager;

    private int valueToSubstractOnCollisionWithEnemy = -10;
    private int scoreBonusForBlueDiamond = 10;
    private int scoreBonusForGreenDiamond = 20;
    private int scoreBonusForRedDiamond = 30;

    private Enemy enemy;

    private bool isPlayerInPositionValueSet;

    private string[] diamondsTypes = {
        "DiamondRed", "DiamondGreen", "DiamondBlue"
    };

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
        isPlayerInPositionValueSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsStarted())
        {
            if (transform.position.x < -1.9f)
            {
                transform.Translate(Vector2.right * 0.5f * Time.deltaTime);
            } else
            {
                if (!isPlayerInPositionValueSet)
                {
                    gameManager.SetIsPlayerInPosition(true);
                }
            }

            if (gameManager.IsStartedAndPlayerInPosition())
            {
                /**
                * Move up when right arrow is pressed.
                **/
                if (Input.GetKey("right"))
                {
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

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        /**
         * On collision with enemy substract value from player score and destroy enemy.
         **/
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("Collision with enemy!");
            enemy.ResetPosition();
            gameManager.AddValueToPlayerScore(valueToSubstractOnCollisionWithEnemy);
        } else if (System.Array.IndexOf(diamondsTypes, other.gameObject.tag) >= 0) 
        {
            Debug.Log("Collision with diamond!");

            if (other.gameObject.tag == diamondsTypes[0])
            {
                gameManager.AddValueToPlayerScore(scoreBonusForRedDiamond);
            } else if (other.gameObject.tag == diamondsTypes[1])
            {
                gameManager.AddValueToPlayerScore(scoreBonusForGreenDiamond);
            } else if (other.gameObject.tag == diamondsTypes[2])
            {
                gameManager.AddValueToPlayerScore(scoreBonusForBlueDiamond);
            }
            
            Diamond diamondScript = other.gameObject.GetComponent<Diamond>();
            diamondScript.ResetPosition();
        } else
        {
            Debug.Log("Other collsion.!");
        }
    }

}
