using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlots[] inventorySlots;
    public int gold;
    public UseItem useitem;
    public TMP_Text goldText;


    private void Start()
    {
        foreach(var slot in inventorySlots)
        {
            slot.UpdateUI();
        }
    }
    public void UseItem(InventorySlots slot)
    {

        if (slot.ItemSO !=null && slot.quantity >=0 )
        {
            Debug.Log("you touch");
            useitem.ApplyItemEffects(slot.ItemSO);

            slot.quantity--;
            if (slot.quantity <= 0)
            {
                slot.ItemSO = null;
            }
            slot.UpdateUI();
        }
    }
    private void OnEnable()
    {
        Loot.OnItemLooted += AddItem;
    }
    private void OnDisable()
    {
        Loot.OnItemLooted -= AddItem;
    }
    public void AddItem(ItemS0 itemso , int quantity)
    {
        if (itemso.isGold)
        {
            gold += quantity;
            goldText.text = gold.ToString();
            return;
        }
        else
        {
            foreach (var slot in inventorySlots)
            {
                if(slot.ItemSO == null)
                {
                    slot.ItemSO = itemso;
                    slot.quantity = quantity;
                    slot.UpdateUI();
                    return;

                }
            }
           
        }
    }
    
}
