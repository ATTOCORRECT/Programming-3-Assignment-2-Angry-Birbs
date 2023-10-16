using System;
using UnityEngine;

public class Birb : MonoBehaviour
{
    #region Provided Code, Do Not Edit
    private Rigidbody2D m_rigidbody;

    private bool m_canExecuteAirSpecial = true;
    public bool CanExecuteAirSpecial
    {
        get
        {
            return m_rigidbody.simulated && m_canExecuteAirSpecial;
        }
    }

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        StopBirbSimulation();
    }

    public void StopBirbSimulation()
    {
        m_rigidbody.simulated = false;
    }

    public void StartBirbSimulation()
    {
        m_rigidbody.simulated = true;
    }

    public void SetPosition( Vector3 position )
    {
        if ( m_rigidbody.simulated )
        {
            m_rigidbody.MovePosition( position );
        }
        else
        {
            transform.position = position;
        }
    }

    public void ExecuteAirSpecial()
    {
        GetComponent<IAirSpecial>().ExecuteAirSpecial();
        m_canExecuteAirSpecial = false;
    }

    private void OnCollisionEnter2D( Collision2D collision )
    {
        m_canExecuteAirSpecial = false;
    }

    public static GameObject MakeBirbCopy( GameObject original )
    {
        Birb newBirb = Instantiate(original).GetComponent<Birb>();
        newBirb.m_canExecuteAirSpecial = false;
        return newBirb.gameObject;
    }
    #endregion

    [Range( 0, 25 )]
    public float LaunchForce = 12;

    public void Launch(Vector3 offset, float maximumStretch, Rigidbody2D rigidbody)
    {
        Vector2 launchVector = -offset / maximumStretch; // divide by max stretch to rescale offset to have a magnitude between 0 and 1
        Vector2 instantaneousVelocity = launchVector * LaunchForce; // scale by launch force
        rigidbody.AddForce(instantaneousVelocity, ForceMode2D.Impulse);
    }
}
