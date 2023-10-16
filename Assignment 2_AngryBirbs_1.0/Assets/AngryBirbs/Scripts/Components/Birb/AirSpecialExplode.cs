using UnityEngine;

public class AirSpecialExplode : MonoBehaviour, IAirSpecial
{
    [Range( 0, 5 )]
    public float BlastRadius = 2;

    public void ExecuteAirSpecial()
    {
        throw new System.NotImplementedException();
    }
}
