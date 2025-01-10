using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private bool panelStats = false; // Tracks whether the panel is active
    public Canvas canvas; // Reference to the Canvas object

    private void Start()
    {
        // Ensure the canvas starts as inactive
        if (canvas != null)
        {
            canvas.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Canvas is not assigned in the Inspector.");
        }
    }

    private void Update()
    {
        // Toggle the canvas visibility and pause state when the Space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            panelStats = !panelStats; // Flip the state of panelStats

                
                
                    // Pause the game and show the canvas
                    Time.timeScale = 0;
                    canvas.gameObject.SetActive(true);
                
               
                
                    // Resume the game and hide the canvas
                    Time.timeScale = 1;
                    canvas.gameObject.SetActive(false);
                
            
           
                Debug.LogError("Canvas is not assigned in the Inspector.");
            
     

    public void HitExitButton()
    {
        Debug.Log("Exiting Game...");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in the Unity Editor
#endif
    }
}
