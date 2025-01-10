using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIScripts : MonoBehaviour
{
    //=============================Hada ta3 esp =============================//
    public GameObject[] statSlots;
    public CanvasGroup statsCanvas;

    private bool panelstats = false;   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panelstats)
            {
                Time.timeScale = 1;
                UpdateAllStats();
                statsCanvas.alpha = 0;
                panelstats = false;
            }
            else
            {
                Time.timeScale = 0;
                UpdateAllStats();
                panelstats = true;
                statsCanvas.alpha = 1;
            }
              
        }
    }
    private void Start()
    {
      UpdateAllStats();
    }
    public void Updatedamage()
    {
        statSlots[0].GetComponentInChildren<TMP_Text>().text = "Damage : "+ StatsManager.Instance.damage;
    }
    public void UpdateSpeed()
    {
        statSlots[1].GetComponentInChildren<TMP_Text>().text = "Speed : " + StatsManager.Instance.speed;
    }
    public void UpdateAllStats()
    {
        Updatedamage();
        UpdateSpeed();
    }


}
