using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class From_MainToMine : MonoBehaviour
{
    int PlayerIndex;
    [Header("Player Parent")]
    public Transform playerParent;


    private void Start()
    {
        selecteTheRightPlayer();
    }


    private void selecteTheRightPlayer()
    {
        for (int i = 0; i < playerParent.childCount; i++)
        {
            if (playerParent.GetChild(i).gameObject.activeInHierarchy == true)
            {
                PlayerPrefs.SetInt("playerSelectedSceneMain" , i);
                return;
            }
           
        }
    }
   
}
