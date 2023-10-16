using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController sm_instance;
    private static Camera sm_camera;

    public static Camera Camera
    {
        get
        {
            if ( null == sm_camera )
            {
                sm_camera = FindObjectOfType<Camera>();
            }
            return sm_camera;
        }
    }

    private void Update()
    {
        if ( Input.GetMouseButtonDown( 0 ) )
        {
            Birb[] birbs = FindObjectsOfType<Birb>();
            foreach( Birb birb in birbs )
            {
                if( birb.CanExecuteAirSpecial )
                {
                    birb.ExecuteAirSpecial();
                }
            }
        }
    }
}
