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
            
            Rigidbody2D birbRigidBody = collision.gameObject.GetComponent<Rigidbody2D>(); // get rigid body

            if (birbRigidBody.velocity.magnitude >= MinimumBreakSpeed) // compare speed
            {
                DestroyTarget(); 
            }
        }
    }

    public void DestroyTarget()
    {
        Destroy( gameObject );
    }
}
