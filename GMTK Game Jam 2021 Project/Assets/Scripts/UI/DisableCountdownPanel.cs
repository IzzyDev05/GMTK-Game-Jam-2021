using UnityEngine;
using System.Collections;

public class DisableCountdownPanel: MonoBehaviour
{
    [SerializeField] GameObject countdownPanel;

    public void DisablePanel() {
        countdownPanel.SetActive(false);
    }
}