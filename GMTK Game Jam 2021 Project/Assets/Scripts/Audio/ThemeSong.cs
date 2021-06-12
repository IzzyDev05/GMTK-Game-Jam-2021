using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeSong : MonoBehaviour
{
    public static ThemeSong instance;
    public static bool isDead = false;

    private AudioSource source;
    private AudioLowPassFilter lowPassFilter;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        source = GetComponent<AudioSource>();
        lowPassFilter = GetComponent<AudioLowPassFilter>();
        source.Play();
    }

    private void Update() {
        if (isDead) {
            lowPassFilter.cutoffFrequency = 900f;
        }
        else {
            lowPassFilter.cutoffFrequency = 22000f;
        }
    }
}