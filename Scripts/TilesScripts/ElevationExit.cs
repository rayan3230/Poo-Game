using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class ElevationExit : MonoBehaviour
{

    public Collider2D[] mountainColliders;
    public Collider2D[] BoundaryColliders;

    private void OnTriggerEnter2D(Collider2D collision)
    {



        if (collision.gameObject.tag == "Player")
        {
            foreach (Collider2D mountain in mountainColliders)
            {
                mountain.enabled = true;
            }
            foreach (Collider2D boundary in BoundaryColliders)
            {
                boundary.enabled = false;
            }
            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 10;
        }

    }

   
}
*/


public class ElevationExit : MonoBehaviour
{
    public Collider2D[] mountainColliders;
    public Collider2D[] boundaryColliders;
    public int exitSortingOrder = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Enable mountain colliders
            foreach (Collider2D mountain in mountainColliders)
            {
                if (mountain != null) mountain.enabled = true;
            }

            // Disable boundary colliders
            foreach (Collider2D boundary in boundaryColliders)
            {
                if (boundary != null) boundary.enabled = false;
            }

            // Change sorting order for player and children
            SpriteRenderer[] renderers = collision.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer renderer in renderers)
            {
                renderer.sortingOrder = 5;
            }
        }
    }
}
