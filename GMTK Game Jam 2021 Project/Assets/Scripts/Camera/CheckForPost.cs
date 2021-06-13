using UnityEngine;

public class CheckForPost : MonoBehaviour
{
    private GameObject volume;

    private void Start() {
        volume = GameObject.FindGameObjectWithTag("PostVolume");

        if (PlayerPrefs.GetInt("PostProcessing") == 1) {
            volume.SetActive(true);
        }
        else {
            volume.SetActive(false);
        }
    }
}