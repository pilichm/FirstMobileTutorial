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
    private Enemy enemy;

    private Diamond diamondRed;
    private Diamond diamondGreen;
    private Diamond diamondBlue;

    private float valueToAddToBackgroundSpeed = 0.5f;
    private float scoreChangeFadeOutSpeed = 3.0f;
    private float valueToAddToEnemyAndDiamondSpeed = 0.2f;

    public TMP_Text stageName;
    public TMP_Text currentScore;
    public TMP_Text scoreChange;

    private int playerScore = 0;
    private int valueToSubstractFromDiamondSpawnDelay = 1;

    private bool isStarted;

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
        enemy = GameObject.Find("Enemy").GetComponent<Enemy>();

        diamondRed = GameObject.Find("DiamondRed").GetComponent<Diamond>();
        diamondGreen = GameObject.Find("DiamondGreen").GetComponent<Diamond>();
        diamondBlue = GameObject.Find("DiamondBlue").GetComponent<Diamond>();

        scoreChange.gameObject.SetActive(false);
        RefreshPlayerScore();

        isStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        int refreshCount = repeatBackground.getRefreshCount();

        if (refreshCount==2) {
            // Change to midday.
            ChangeBackgoundScene(0);
        } else if (refreshCount == 4)
        {
            // Change to evening.
            ChangeBackgoundScene(1);
        } else if (refreshCount == 6)
        {
            // Change to sunset.
            ChangeBackgoundScene(2);
        } else if (refreshCount == 8)
        {
            // Change to midnight.
            ChangeBackgoundScene(3);
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
            scoreChange.color = Color.green;
            currentScore.color = Color.green;
        } else
        {
            scoreChange.text = "" + valueToAdd;
            scoreChange.color = Color.red;
            currentScore.color = Color.red;
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
        currentScore.color = Color.white;
    }

    private void ChangeBackgoundScene(int backgroundIndex)
    {
        backgroundRenderer.sprite = backgroundSprites[backgroundIndex];
        moveBackgroundImageLeft.increaseSpeedByValue(valueToAddToBackgroundSpeed);
        stageName.text = stageNames[backgroundIndex + 1];
        enemy.addValueToSpeed(valueToAddToEnemyAndDiamondSpeed);

        diamondRed.addValueToSpeed(valueToAddToEnemyAndDiamondSpeed);
        diamondGreen.addValueToSpeed(valueToAddToEnemyAndDiamondSpeed);
        diamondBlue.addValueToSpeed(valueToAddToEnemyAndDiamondSpeed);

        diamondRed.SubstractValueFromDelay(valueToSubstractFromDiamondSpawnDelay);
        diamondGreen.SubstractValueFromDelay(valueToSubstractFromDiamondSpawnDelay);
        diamondBlue.SubstractValueFromDelay(valueToSubstractFromDiamondSpawnDelay);
    }

    public bool IsStarted()
    {
        return isStarted;
    }
}
