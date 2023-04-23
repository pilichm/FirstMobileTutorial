using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackgroundImageLeft : MonoBehaviour
{
    private float speed = 15.0f;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsStartedAndPlayerInPosition())
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }    
    }

    public void increaseSpeedByValue(float valueToAddToSpeed)
    {
        speed += valueToAddToSpeed;
    }
}
