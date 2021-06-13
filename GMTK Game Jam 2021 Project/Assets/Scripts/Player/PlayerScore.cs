using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public static int playerScore = 0;

    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text scoreStat;
    [SerializeField] TMP_Text highScoreStat;

    private void Update() {
        scoreText.text = playerScore.ToString();
        scoreStat.text = playerScore.ToString();

        if (playerScore > PlayerPrefs.GetInt("HighScore", 0)) {
            PlayerPrefs.SetInt("HighScore", playerScore);
        }

        highScoreStat.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}