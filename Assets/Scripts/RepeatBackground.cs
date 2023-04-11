using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatWidth;
    private int refreshCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 10.0f)
        {
            transform.position = startPosition;
            refreshCount += 1;
        }
    }

    public int getRefreshCount()
    {
        return refreshCount;
    }
}
