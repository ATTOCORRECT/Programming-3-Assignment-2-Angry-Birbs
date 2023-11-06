using UnityEngine;

public class AirSpecialBounce : MonoBehaviour, IAirSpecial
{
    [Range( 0, 1 )]
    public float SlowDownFactor = 1;

    public void ExecuteAirSpecial()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        Vector2 velocity = rigidbody.velocity;
        if (velocity.y <= 0) // velocity reflection when moving upward
        {
            // new velocity is the velocity i want after the impulse
            Vector2 newVelocity = new Vector2(velocity.x, -velocity.y * SlowDownFactor); // slowfactor was changed to only influence vertical speed because killing the horizontal speed too feels bad to play with.
            
            Vector2 impulse = newVelocity - velocity; // impulse is the difference
            rigidbody.AddForce(impulse, ForceMode2D.Impulse);
        } 
    }
}
