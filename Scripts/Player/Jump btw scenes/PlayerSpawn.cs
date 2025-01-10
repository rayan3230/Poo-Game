using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;



public class PlayerSpawn : MonoBehaviour
{
    [Header("Player Parent")]
    public Transform playerParent; // Reference to "==player==" GameObject

    [Header("Camera Setup")]
    public CinemachineVirtualCamera virtualCamera;

    
    
    private void Start()
    {
        
        int selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0); // Get the selected character index from PlayerPrefs (default to 0 if not set)

       
        if (selectedCharacter >= 0 && selectedCharacter < playerParent.childCount) // Check if the selected character is valid
        {
            
            for (int i = 0; i < playerParent.childCount; i++) // Deactivate all child objects (if needed)
            {
                playerParent.GetChild(i).gameObject.SetActive(false);
            }

            // Activate the selected character
            playerParent.GetChild(selectedCharacter).gameObject.SetActive(true);

            // Assign the virtual camera t
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







