using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MineEntranve : MonoBehaviour
{

    public Canvas canvas;
    private void Start()
    {
        canvas.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void GoBack()
    {
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void EnterTheMine()
    {
        SceneManager.LoadScene(2);
    }
}
