using UnityEngine;
using System.Collections;
using TMPro;

public class SpawnerCountdown : MonoBehaviour
{
    [SerializeField] int countdownSeconds;
    [SerializeField] GameObject countdownPanel;
    [SerializeField] TMP_Text countdownText;
    private CameraMovement cameraMovement;
    private Spawner spawner;

    private void Start() {
        countdownPanel.SetActive(true);
        spawner = GetComponent<Spawner>();
        cameraMovement = GetComponentInParent<CameraMovement>();
        spawner.enabled = false;
        cameraMovement.enabled = false;
        StartCoroutine(Countdown(countdownSeconds));
    }

    private IEnumerator Countdown(int seconds) {
        int count = seconds;

        while (count > 0) {
            countdownText.text = count.ToString();
            yield return new WaitForSeconds(1);
            count--;
        }

        // Countdown has finished
        EnableSpawning();
    }

    private void EnableSpawning() {
        spawner.enabled = true;
        cameraMovement.enabled = true;
        countdownPanel.GetComponent<Animator>().SetTrigger("FadeOut");
    }
}