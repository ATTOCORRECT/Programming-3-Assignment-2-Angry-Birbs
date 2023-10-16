using UnityEngine;

public class AirSpecialBounce : MonoBehaviour, IAirSpecial
{
    [Range( 0, 1 )]
    public float SlowDownFactor = 1;

    public void ExecuteAirSpecial()
    {
        throw new System.NotImplementedException();
    }
}
