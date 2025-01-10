using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;
    public TMP_Text healthtext;
    public UIScripts StatsUI;


    [Header("Combat Stats")]
    public int damage;
    public float weaponRange;
    public float weaponDamage;
    public float KnockPower;
    public float KnockbackTime;
    public float stuntime;
    public int Arrowdamage;

    [Header("Movement Stats")]
    public float speed;

    [Header("Health Stats ")]
    public int MaxHP ;
    public int CurrentHP ;


    


    private CharacterBase CreateCharacterInstance(int selectedOption)
    {
        switch (selectedOption)
        {
            case 0: return new knight();
            case 1: return new Archer();
            case 2: return new Pawn();
            default: return null;
        }
    }


    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else 
            Destroy(gameObject);

       
        
    }
    private void Start()
    {
        // Fetch the selected character option
        int selectedOption = PlayerPrefs.GetInt("SelectedCharacter", 0);

        // Create a character instance based on the selected option
        CharacterBase character = CreateCharacterInstance(selectedOption);

        // Retrieve and apply stats from the character
        if (character != null)
        {
            MaxHP = character.MaxHP;
            CurrentHP = MaxHP;
            damage = character.Damage;
        }
        else
        {
            Debug.LogError("Invalid character selection!");
        }
    }




    public void UpdateMaxHealth(int amount)
    {
        MaxHP += amount;
        healthtext.text = "HP :" + CurrentHP + "/" + MaxHP;
    }
    public void Updatedamage(int amount)
    {
        damage += amount;

        StatsUI.UpdateAllStats();
    }
    public void UpdateHealth(int amount)
    {
        if(CurrentHP < MaxHP)
        {
            CurrentHP += amount;
            healthtext.text = "HP :" + CurrentHP + "/" + MaxHP;
        }
        
    }
    public void UpdateSpeed(int amount)
    {
        speed += amount;
        
        StatsUI.UpdateAllStats();
    }


}
