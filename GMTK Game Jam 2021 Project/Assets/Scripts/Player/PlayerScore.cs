using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int playerScore = 0;

    private void Update() {
        Debug.Log(playerScore);
    }
}