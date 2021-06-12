using UnityEngine;
using TMPro;

public class LossManager : MonoBehaviour
{
    public static int numberOfLosses = 0;
    
    [SerializeField] TMP_Text lossText;
    private int chancesLeft;
    private bool hasCounted = false;

    private void Update() {
        CountLosses();
        UpdateCounter();
    }

    private void CountLosses() {
        chancesLeft = 5 - numberOfLosses;

        if (!hasCounted && ThemeSong.isDead) {
            hasCounted = true;
            numberOfLosses++;
        }
    }

    private void UpdateCounter() {
        lossText.text = chancesLeft.ToString();
    }
}