using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class GameManager : MonoBehaviour
{
    public Sprite [] backgroundSprites;
    private GameObject background;
    private RepeatBackground repeatBackground;
    private MoveBackgroundImageLeft moveBackgroundImageLeft;
    private SpriteRenderer backgroundRenderer;
    private float valueToAddToBackgroundSpeed = 2.0f;

    public TMP_Text stageName;

    private string[] stageNames = {
        "Stage 1: Daybreak", "Stage 2: Midday", "Stage 3: Evening", "Stage 4: Sunset", "Stage 5: Midnight"
    };

    // Start is called before the first frame update
    void Start()
    {
        background = GameObject.Find("Background");
        repeatBackground = background.GetComponent<RepeatBackground>();
        moveBackgroundImageLeft = background.GetComponent<MoveBackgroundImageLeft>();
        backgroundRenderer = background.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        int refreshCount = repeatBackground.getRefreshCount();

        if (refreshCount==2) {
            // Change to midday.
            backgroundRenderer.sprite = backgroundSprites[0];
            moveBackgroundImageLeft.increaseSpeedByValue(valueToAddToBackgroundSpeed);
            stageName.text = stageNames[1];
        } else if (refreshCount == 4)
        {
            // Change to evening.
            backgroundRenderer.sprite = backgroundSprites[1];
            moveBackgroundImageLeft.increaseSpeedByValue(valueToAddToBackgroundSpeed);
            stageName.text = stageNames[2];
        } else if (refreshCount == 6)
        {
            // Change to sunset.
            backgroundRenderer.sprite = backgroundSprites[2];
            moveBackgroundImageLeft.increaseSpeedByValue(valueToAddToBackgroundSpeed);
            stageName.text = stageNames[3];
        } else if (refreshCount == 8)
        {
            // Change to midnight.
            backgroundRenderer.sprite = backgroundSprites[3];
            moveBackgroundImageLeft.increaseSpeedByValue(valueToAddToBackgroundSpeed);
            stageName.text = stageNames[4];
        }

        /**
         * Move ship on touch or click on buttons. 
         **/
        
    }
}
