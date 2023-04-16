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
    private PlayerController playerController;
    private SpriteRenderer backgroundRenderer;

    private float valueToAddToBackgroundSpeed = 2.0f;
    private float scoreChangeFadeOutSpeed = 3.0f;

    public TMP_Text stageName;
    public TMP_Text currentScore;
    public TMP_Text scoreChange;

    private int playerScore = 0;

    private string[] stageNames = {
        "Stage 1: Daybreak", "Stage 2: Midday", "Stage 3: Evening", "Stage 4: Sunset", "Stage 5: Midnight"
    };

    // Start is called before the first frame update
    void Start()
    {
        background = GameObject.Find("Background");
        repeatBackground = background.GetComponent<RepeatBackground>();
        moveBackgroundImageLeft = background.GetComponent<MoveBackgroundImageLeft>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        backgroundRenderer = background.GetComponent<SpriteRenderer>();

        scoreChange.gameObject.SetActive(false);
        RefreshPlayerScore();
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
         * For testing up and down key arrows will add or substract value from player score. 
         **/
        if (Input.GetKeyDown("up"))
        {
            AddValueToPlayerScore(50);
        }

        if (Input.GetKeyDown("down"))
        {
            AddValueToPlayerScore(-50);
        }
    }

    void RefreshPlayerScore()
    {
        currentScore.text = "SCORE: " + playerScore;
    }

    public void AddValueToPlayerScore(int valueToAdd)
    {
        playerScore += valueToAdd;
        RefreshPlayerScore();
        scoreChange.gameObject.SetActive(true);

        if (valueToAdd > 0)
        {
            scoreChange.text = "+" + valueToAdd;
            scoreChange.color = new Color(0, 255, 0, 255);
        } else
        {
            scoreChange.text = "" + valueToAdd;
            scoreChange.color = new Color(255, 0, 0, 255);
        }

        StartCoroutine(FadeOut());
    }

    /**
     * Method for fading out text displaying change in player score. 
     **/
    private IEnumerator FadeOut()
    {
        scoreChange.color = new Color(scoreChange.color.r, scoreChange.color.g, scoreChange.color.b, 1);

        while (scoreChange.color.a > 0.0f)
        {
            scoreChange.color = new Color(scoreChange.color.r, scoreChange.color.g, scoreChange.color.b, 
                scoreChange.color.a - (Time.deltaTime * scoreChangeFadeOutSpeed));
            yield return null;
        }

        scoreChange.gameObject.SetActive(false);
    }
}
