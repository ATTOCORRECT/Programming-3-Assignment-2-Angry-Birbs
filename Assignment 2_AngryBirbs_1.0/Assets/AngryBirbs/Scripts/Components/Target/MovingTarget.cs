using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    [Range( 0, 5 )]
    public float HalfPathDistance = 3;
    [Range( 0, 5 )]
    public float MovementSpeed = 2;

    Vector2 velocity;
    Vector2 startPosition;

    private void Start()
    {
        velocity = new Vector2(0, MovementSpeed);
        startPosition = gameObject.GetComponent<Rigidbody2D>().position;
    }
    private void FixedUpdate()
    {
        Vector2 relativePosition = gameObject.GetComponent<Rigidbody2D>().position - startPosition;

        if (relativePosition.y > HalfPathDistance)
        {
            velocity *= -1;
            gameObject.GetComponent<Rigidbody2D>().position = new Vector2(0, HalfPathDistance) + startPosition;
        }

        if (relativePosition.y < -HalfPathDistance)
        {
            velocity *= -1;
            gameObject.GetComponent<Rigidbody2D>().position = new Vector2(0, -HalfPathDistance) + startPosition;
        }

        gameObject.GetComponent<Rigidbody2D>().position += velocity * Time.fixedDeltaTime;
    }
}
