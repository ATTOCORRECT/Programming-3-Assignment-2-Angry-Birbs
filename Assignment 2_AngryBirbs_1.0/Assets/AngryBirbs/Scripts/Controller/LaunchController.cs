using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchController : MonoBehaviour
{
    [SerializeField]
    private CircleCollider2D m_touchCollider;
    [SerializeField]
    private CircleCollider2D m_stretchCollider;

    [SerializeField]
    private GameObject RedBirdPrefab;
    [SerializeField]
    private GameObject BlueBirdPrefab;
    [SerializeField]
    private GameObject YellowBirdPrefab;

    private Launcher m_launcher;
    private bool m_launching = false;

    private void Start()
    {
        m_launcher = GetComponentInChildren<Launcher>();
    }


    // Update is called once per frame
    void Update ()
    {
        Vector3 worldTouchPoint = GameController.Camera.ScreenToWorldPoint( Input.mousePosition );
        worldTouchPoint.z = 0;
        if ( m_launcher.IsLoaded && !m_launching && Input.GetMouseButtonDown( 0 ) && m_touchCollider.OverlapPoint( worldTouchPoint ) )
        {
            m_launching = true;
        }

        if ( m_launching && Input.GetMouseButtonUp( 0 ) )
        {
            m_launching = false;

            // Launch
            m_launcher.Launch( GetCurrentStretchOffset( worldTouchPoint ), m_stretchCollider.radius );
            ResetElastics();
        }

        if ( m_launching )
        {
            if ( m_stretchCollider.OverlapPoint( worldTouchPoint ) )
            {
                m_launcher.SetLaunchPosition( worldTouchPoint );
            }
            else
            {
                Vector3 localTouch = m_stretchCollider.transform.InverseTransformPoint(worldTouchPoint);
                m_launcher.SetLaunchPosition( m_stretchCollider.transform.TransformPoint( localTouch.normalized * m_stretchCollider.radius ) );
            }
        }

        if ( Input.GetButtonDown( "LoadRedBirb" ) )
        {
            m_launcher.Load( RedBirdPrefab, m_touchCollider.transform.position );
        }
        else if ( Input.GetButtonDown( "LoadBlueBirb" ) )
        {
            m_launcher.Load( BlueBirdPrefab, m_touchCollider.transform.position );
        }
        else if ( Input.GetButtonDown( "LoadYellowBirb" ) )
        {
            m_launcher.Load( YellowBirdPrefab, m_touchCollider.transform.position );
        }
    }

    private Vector3 GetCurrentStretchOffset( Vector3 worldTouchPoint )
    {
        if ( m_stretchCollider.OverlapPoint( worldTouchPoint ) )
        {
            return m_stretchCollider.transform.InverseTransformPoint( worldTouchPoint );
        }
        else
        {
            Vector3 localTouch = m_stretchCollider.transform.InverseTransformPoint(worldTouchPoint);
            localTouch.Normalize();
            localTouch *= m_stretchCollider.radius;
            return localTouch;
        }
    }

    private void ResetElastics()
    {
        m_launcher.SetElasticPosition( m_touchCollider.transform.position );
    }
}
