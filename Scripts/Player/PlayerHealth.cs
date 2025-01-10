using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance; // Singleton instance for easy access
    public TMP_Text healthText; // Reference to the UI text displaying health
    public Animator anim; // Animator for handling player animations

    public void Update()
    {
        // Update the health display in the UI every frame
        healthText.text = "HP :" + StatsManager.Instance.CurrentHP + "/" + StatsManager.Instance.MaxHP;
    }

    public void ChangeHp(int amountDamage)
    {
        // Reduce current health by the amount of damage
        StatsManager.Instance.CurrentHP -= amountDamage;

        // Update the health text immediately after taking damage
        healthText.text = "HP :" + StatsManager.Instance.CurrentHP + "/" + StatsManager.Instance.MaxHP;

        // Check if health is zero or below
        if (StatsManager.Instance.CurrentHP <= 0)
        {
            anim.SetBool("isdead", true); // Trigger death animation
            
           StartCoroutine(DestroyAfterDelay(2f)); // Adjust the delay as needed
            // Remove the player object from the scene
        }
    }

    
        public void returnMenu()
    {
        SceneManager.LoadScene(0);
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
        returnMenu();
    }
}
