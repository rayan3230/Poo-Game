using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UseItem : MonoBehaviour
{
    public void ApplyItemEffects(ItemS0 item)
    {
        Debug.Log($"Applying effects of item: {item.itemName}");
        if (item.CurrentHP > 0)
        {
            StatsManager.Instance.UpdateHealth(item.CurrentHP);
            //PlayerHealth.Instance.ChangeHp(item.CurrentHP);
        }
         if(item.damage > 0)
        {
            StatsManager.Instance.Updatedamage(item.damage);

        }
        if (item.MaxHP > 0)
        {
            StatsManager.Instance.UpdateMaxHealth(item.MaxHP);
        }
        if (item.speed > 0)
        {
            StatsManager.Instance.UpdateSpeed(item.speed);
        }
        if (item.duration > 0)
        {
            StartCoroutine(EffectTimer(item, item.duration));
        }
    }
    private IEnumerator EffectTimer(ItemS0 item , float duration)
        {
            yield return new WaitForSeconds(duration);
        if (item.CurrentHP > 0)
        {
            StatsManager.Instance.UpdateHealth(-item.CurrentHP);
        }
        if (item.MaxHP > 0)
        {
            StatsManager.Instance.UpdateMaxHealth(-item.MaxHP);
        }
        if (item.speed > 0)
        {
            StatsManager.Instance.UpdateSpeed(-item.speed);
        }
    }

}
