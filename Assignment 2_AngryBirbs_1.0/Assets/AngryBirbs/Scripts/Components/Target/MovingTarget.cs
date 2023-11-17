using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    [Range( 0, 5 )]
    public float HalfPathDistance = 3;
    [Range( 0, 5 )]
    public float MovementSpeed = 2;

    Vector2 startPosition;
    Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        startPosition = rigidbody.position;
        rigidbody.velocity = Vector2.up * MovementSpeed; // initial upward velocity
    }
    private void FixedUpdate()
    {
        Vector2 relativePosition = rigidbody.position - startPosition; // position relative to the starting position

        if (relativePosition.y > HalfPathDistance) // if higher than half path
        {
            rigidbody.velocity = Vector2.down * MovementSpeed; // go down
            rigidbody.position = Vector2.up * HalfPathDistance + startPosition; // snap to higher position
        }

        if (relativePosition.y < -HalfPathDistance) // if lower than negative half path
        {
            rigidbody.velocity = Vector2.up * MovementSpeed; // go up
            rigidbody.position = Vector2.down * HalfPathDistance + startPosition; // snap to lower position
        }
    }
}
