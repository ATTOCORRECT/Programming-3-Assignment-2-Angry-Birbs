using System.Collections.Generic;
using UnityEngine;

public class AirSpecialExplode : MonoBehaviour, IAirSpecial
{
    [Range( 0, 5 )]
    public float BlastRadius = 2;

    private List<Collider2D> targetColliders = new List<Collider2D>();

    public void Start()
    {
        // collider setup
        CircleCollider2D ExplosionCollider = gameObject.AddComponent<CircleCollider2D>();
        ExplosionCollider.isTrigger = true;
        ExplosionCollider.radius = BlastRadius;
    }

    public void ExecuteAirSpecial()
    {
        for ( int i = 0; i < targetColliders.Count; i++ ) // destroy all objects currently in the list
        {
            targetColliders[i].gameObject.GetComponent<Target>().DestroyTarget();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // on enter
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Target") // if its of the layer "Target"
        {
            if (!targetColliders.Contains(collision)) // and isnt already in the list
            {
                targetColliders.Add(collision); // add to list
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // on exit 
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Target") // if its of the layer "Target"
        {
            targetColliders.Remove(collision); // remove from list
        }
    }
}
