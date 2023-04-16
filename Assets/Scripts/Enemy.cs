using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 1.0f;
    private float xMoveBoundary = -4.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        /**
         * Destroy enemy when it has left the screen.
         **/
        if (transform.position.x < xMoveBoundary)
        {
            Destroy(gameObject);
        }
    }
}
