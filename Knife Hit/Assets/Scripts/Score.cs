using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text[] scoreText;
    [SerializeField] private Text maxScoreText;
    private int score;
    private int maxScore;

    public int MaxScore
    {
        get
        {
            return maxScore;
        }
        set
        {
            maxScore = value;
        }
    }

    private void Update()
    {
        maxScoreText.text = maxScore.ToString();
        for (int i = 0; i < scoreText.Length; i++)
        {
            scoreText[i].text = score.ToString();
        }
    }

    public void AddScore(int addScore)
    {
        score += addScore;

        if(maxScore < score)
        {
            maxScore = score;
            Save.SaveRecord(maxScore);
        }
    }

    public void ResetScore()
    {
        score = 0;
    }
}
