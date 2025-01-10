using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public ItemS0 Item;
    public SpriteRenderer sr;
    public Animator anim;
    public static event Action<ItemS0, int> OnItemLooted;

    public int quantity;

    private void OnValidate()
    {
        if (Item == null)
        {
            return;
        }
            sr.sprite = Item.spriteitem;
            this.name = Item.itemName;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            anim.Play("LootAnim");
            OnItemLooted?.Invoke(Item , quantity);
            Destroy(gameObject , .5f);
        }
    }
}
