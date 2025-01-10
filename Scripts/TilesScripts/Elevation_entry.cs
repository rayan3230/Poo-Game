using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class Elevation_entry : MonoBehaviour
{
    public Collider2D[] mountainColliders;
    public Collider2D[] BoundaryColliders;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (Collider2D mountain in mountainColliders)
            {
                mountain.enabled = false;
            }
           
            foreach (Collider2D boundary in BoundaryColliders)
            {
                boundary.enabled = true;
            }
                    collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 15;
        }
       
    }
}
*/


public class ElevationEntry : MonoBehaviour
{
    public Collider2D[] mountainColliders;
    public Collider2D[] boundaryColliders;
    public int entrySortingOrder = 15;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Disable mountain colliders
            foreach (Collider2D mountain in mountainColliders)
            {
                 mountain.enabled = false;
            }

            // Enable boundary colliders
            foreach (Collider2D boundary in boundaryColliders)
            {
              boundary.enabled = true;
            }

            // Change sorting order for player and children
            SpriteRenderer[] renderers = collision.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer renderer in renderers)
            {
                renderer.sortingOrder = entrySortingOrder;
            }
        }
    }
}

