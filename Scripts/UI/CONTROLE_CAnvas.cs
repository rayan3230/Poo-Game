using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CONTROLE_CAnvas : MonoBehaviour
{

    public Canvas controlsCanvas; // Attach the canvas displaying controls in the inspector
    public float displayDuration = 5.0f; // Duration in seconds to show the controls

    private float timer;

    void Start()
    {
        if (controlsCanvas == null)
        {
            Debug.LogError("Controls Canvas is not assigned in the inspector.");
            return;
        }

        controlsCanvas.enabled = true; // Show the controls at the start
        timer = displayDuration; // Initialize the timer
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime; // Count down the timer
            if (timer <= 0)
            {
                controlsCanvas.enabled = false; // Hide the controls when the time is up
            }
        }
    }
}


