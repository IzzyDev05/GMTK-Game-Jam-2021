using UnityEngine;
using System.Collections;

public class DestroyCountdownPanel : MonoBehaviour
{
    [SerializeField] GameObject countdownPanel;

    public void DestroyPanel() {
        Destroy(countdownPanel);
    }
}