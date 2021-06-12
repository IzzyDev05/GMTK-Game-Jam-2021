using System.Collections;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] float startTime = 7f;
    [SerializeField] TMP_Text countdownText;
    private float currentTime = 0f;

    private void Start() {
        currentTime = startTime;
    }

    private void Update() {
        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0) {
            currentTime = 0;
        }
    }
}