using UnityEngine;

public class AirSpecialSplit : MonoBehaviour, IAirSpecial
{
    public float SplitAngleInDegrees = 10;

    public void ExecuteAirSpecial()
    {
        GameObject BirbUp = Birb.MakeBirbCopy(gameObject);
        GameObject BirbDown = Birb.MakeBirbCopy(gameObject);

        Rigidbody2D rigidbody = gameObject.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidbodyBirdUp = BirbUp.GetComponent<Rigidbody2D>();
        Rigidbody2D rigidbodyBirdDown = BirbDown.GetComponent<Rigidbody2D>();

        rigidbodyBirdUp.simulated = true;
        rigidbodyBirdDown.simulated = true;

        Vector2 originalVelocity = rigidbody.velocity;
        Vector2 velocityUp = RotateVector2D(SplitAngleInDegrees, originalVelocity);
        Vector2 velocityDown = RotateVector2D(-SplitAngleInDegrees, originalVelocity);

        rigidbodyBirdUp.AddForce(velocityUp, ForceMode2D.Impulse);
        rigidbodyBirdDown.AddForce(velocityDown, ForceMode2D.Impulse);

    }

    /// <summary>
    /// Rotates a Vector3 about the z axis an ammount angle in degrees
    /// </summary>
    /// <returns>A rotated Vector3.</returns>
    Vector3 RotateVector2D(float angle, Vector3 v)
    {
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        Matrix4x4 m = Matrix4x4.Rotate(rotation);
        return m.MultiplyPoint3x4(v);
    }
}
