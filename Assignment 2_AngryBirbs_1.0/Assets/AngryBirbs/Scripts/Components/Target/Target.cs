using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [Range( 0, 20 )]
    public float MinimumBreakSpeed = 10;

    private void OnCollisionEnter2D( Collision2D collision )
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Birb") // if its of the layer "Birb"
        {
            Debug.Log(collision.relativeVelocity.magnitude);

            if (collision.relativeVelocity.magnitude >= MinimumBreakSpeed) // and relative speed is less than minimum break
            {
                DestroyTarget(); 
            }
        }
    }

    public void DestroyTarget()
    {
        Destroy(gameObject);
    }
}
