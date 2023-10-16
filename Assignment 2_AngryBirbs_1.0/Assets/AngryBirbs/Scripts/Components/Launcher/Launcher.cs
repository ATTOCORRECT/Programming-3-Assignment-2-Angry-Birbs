using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    private Birb m_loadedBirb;
    private LineRenderer[] m_elasticRenderers;

    public bool IsLoaded { get { return m_loadedBirb != null; } }

    public void Start()
    {
        m_elasticRenderers = GetComponentsInChildren<LineRenderer>();
    }

    public void Load( GameObject birbPrefab, Vector3 position )
    {
        if ( null != m_loadedBirb )
        {
            Destroy( m_loadedBirb.gameObject );
        }
        m_loadedBirb = Instantiate<GameObject>( birbPrefab ).GetComponent<Birb>();
        m_loadedBirb.SetPosition( position );
    }

    public void Launch( Vector3 offset, float maximumStretch )
    {
        if ( IsLoaded )
        {
            m_loadedBirb.StartBirbSimulation();
            m_loadedBirb.Launch( offset, maximumStretch, m_loadedBirb.GetComponentInChildren<Rigidbody2D>() );

            m_loadedBirb = null;
        }
    }

    public void SetLaunchPosition( Vector3 worldLaunchPosition )
    {
        SetElasticPosition( worldLaunchPosition );
        m_loadedBirb.SetPosition( worldLaunchPosition );
    }

    public void SetElasticPosition( Vector3 worldPosition )
    {
        Vector3 localPosition = transform.InverseTransformPoint( worldPosition );
        m_elasticRenderers[ 0 ].SetPosition( 1, localPosition );
        m_elasticRenderers[ 1 ].SetPosition( 1, localPosition );
    }
}
