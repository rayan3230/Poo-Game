using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class InsideMineSpawn : MonoBehaviour
{
    
    
        [Header("Player Parent")]
        public Transform playerParent; // Reference to "==player==" GameObject

        [Header("Camera Setup")]
        public CinemachineVirtualCamera virtualCamera;



        private void Start()
        {
            // Get the selected character index from PlayerPrefs (default to 0 if not set)
            int selectedCharacter = PlayerPrefs.GetInt("playerSelectedSceneMain", 0);

            // Check if the selected character is valid
            if (selectedCharacter >= 0 && selectedCharacter < playerParent.childCount)
            {
                // Deactivate all child objects (if needed)
                for (int i = 0; i < playerParent.childCount; i++)
                {
                    playerParent.GetChild(i).gameObject.SetActive(false);
                }

                // Activate the selected character
                playerParent.GetChild(selectedCharacter).gameObject.SetActive(true);

                // Assign the virtual camera to follow the character
                if (virtualCamera != null)
                {
                    virtualCamera.Follow = playerParent.GetChild(selectedCharacter).transform;
                }
            }
            else
            {
                Debug.LogError("Invalid selected character index: " + selectedCharacter);
            }
        }
    }


