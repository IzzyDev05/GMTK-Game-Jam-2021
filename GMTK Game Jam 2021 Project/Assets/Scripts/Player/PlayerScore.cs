using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public static int playerScore = 0;

    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text scoreStat;

    private void Update() {
        scoreText.text = playerScore.ToString();
        scoreStat.text = playerScore.ToString();
    }
}