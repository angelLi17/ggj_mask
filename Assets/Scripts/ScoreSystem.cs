using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem instance;
    private float survivalTimer = 0f;
    public int survivalPoints = 100;
    public int points = 50;
    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        UpdateUI();
    }
    void Update()
    {
        survivalTimer += Time.deltaTime;

        if (survivalTimer >= 30f)
        {
            AddPoints(survivalPoints);
            survivalTimer = 0f;
        }
    }

    public void AddPoints(int amount)
    {
        score += amount;
        UpdateUI();
    }
    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
    }
}
