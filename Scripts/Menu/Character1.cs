using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;


public class Character1 : MonoBehaviour
{
    [Header("Character Database")]
    public Sprite[] characterSprites; // Array to store character sprites

    [Header("Character Display")]
    public SpriteRenderer spriteRenderer; // Renderer for displaying the character sprite

    public static int selectedOption = 0;// Currently selected character index
    private int option;

    [Header ("Text")]
    public TMP_Text NameoftheCharacterText;

    private void Update ()
    {
        // Initialize the first character sprite at the start
        if (characterSprites.Length > 0)
        {
            option = UpdateCharacter(selectedOption);
            switch (selectedOption)
            {
                case 0:
                    NameoftheCharacterText.text = "Warrior ";
                    break;
                case 1:
                    NameoftheCharacterText.text = "Archer";
                    break;
                case 2:
                    NameoftheCharacterText.text = "Pawn";
                    break;
            }
            ConfirmSelection(option);
        }
        
    }
   

    public void NextOption()
    {
        selectedOption++;
        
        
        if (selectedOption >= characterSprites.Length)
        {
            selectedOption = 0; // Loop back to the first option
        }
        UpdateCharacter(selectedOption);
    }

    public void PreviousOption()
    {
        selectedOption--;
        if (selectedOption < 0)
        {
            selectedOption = characterSprites.Length - 1; // Loop to the last option
        }
        UpdateCharacter(selectedOption);
    }

    public int UpdateCharacter(int optionIndex)
    {
        if (characterSprites.Length > 0 && optionIndex >= 0 && optionIndex < characterSprites.Length)
        {
            // Update the SpriteRenderer's sprite to the selected character sprite
            spriteRenderer.sprite = characterSprites[optionIndex];
        }
        else
        {
            Debug.LogError("Invalid character sprite index!");
        }
        switch (optionIndex)
        {
            case 0:
                spriteRenderer.transform.localScale = new Vector3(7.765935f, 7.51083f, 7.51083f);
                break;
            case 1:
                spriteRenderer.transform.localScale = new Vector3(8.83256f, 8.83256f, 8.83256f);
                break;
            case 2:
                spriteRenderer.transform.localScale = new Vector3(6.834033f, 6.834033f, 6.834033f);
                break;
        }
        return optionIndex;
    }
    public void ConfirmSelection(int selectedIndex)
    {

        PlayerPrefs.SetInt("SelectedCharacter", selectedIndex); // Save selection
        Debug.Log("Selected Character: " + selectedIndex);
    }
    public void nextScene(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }

    
}



