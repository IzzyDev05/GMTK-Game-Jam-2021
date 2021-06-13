using UnityEngine;

public class EnablePostProcessing : MonoBehaviour
{
    private bool isEnabled = true;
    private GameObject volume;

    private void Start() {
        volume = GameObject.FindGameObjectWithTag("PostVolume");
    }

    public void HandleInput() {
        isEnabled = !isEnabled;
    }

    private void Update() {
        if (isEnabled) {
            PlayerPrefs.SetInt("PostProcessing", 1);
        }
        else {
            PlayerPrefs.SetInt("PostProcessing", 0);
        }

        if (PlayerPrefs.GetInt("PostProcessing") == 1) {
            volume.SetActive(true);
        }
        else {
            volume.SetActive(false);
        }
    }
}