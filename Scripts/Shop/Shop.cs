using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("Canvas")]
    public Canvas canvasUI;
    public Canvas Canvashop;
    private void Start()
    {
        canvasUI.gameObject.SetActive(false);
        Canvashop.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canvasUI.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canvasUI.gameObject.SetActive(false);
        }
    }

    public void ShopOn()
    {
       
        canvasUI.gameObject.SetActive(false);
        Canvashop.gameObject.SetActive(true); 
        Time.timeScale = 0; //freeze l jeux
    }
    public void ShopOff()
    {
        Canvashop.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    

}
