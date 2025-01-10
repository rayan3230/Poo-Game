using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EXPManager : MonoBehaviour
{
    public int level;
    public int currentExp;
    public int ExpToLevel = 10;
    public float ExpGrowthMultiplier = 1.2f; //20% exp every level
    public Slider ExpSlider;
    public TMP_Text currentLeveltext;
    

    private void Start()
    {
        UpdateUI();
    }
    public void GameExperience(int amount)
    {
        currentExp += amount;
        if (currentExp >= ExpToLevel) 
        {
            LevelUp();
        }
        UpdateUI();
    }

    private void OnEnable()
    {
        Enemy_Health.OnMonsterDefeated += GameExperience;
    }
    private void OnDisable()
    {
        Enemy_Health.OnMonsterDefeated -= GameExperience;
    }
    public void LevelUp()
    {
        level++;
        currentExp -= ExpToLevel;
        ExpToLevel = Mathf.RoundToInt(ExpToLevel * ExpGrowthMultiplier);

    }
    public void UpdateUI()
    {
        ExpSlider.maxValue = ExpToLevel;
        ExpSlider.value = currentExp;
        currentLeveltext.text = "Level: " + level;
    }
}
