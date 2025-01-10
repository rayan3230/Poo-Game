using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="New Item")]
public class ItemS0 : ScriptableObject
{
    public string itemName;
    [TextArea] public string itemDescreption;
    public Sprite spriteitem;

    public bool isGold;

    [Header("Stats")]
    public int speed;
    public int damage;
    public int MaxHP ;
    public int CurrentHP ;

    [Header("For temp items")]
    public int duration;

}
