using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorShipController : MonoBehaviour
{
    static InteriorShipController instance;
    public ShipMovement shipMovement;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public float angle;

    // Update is called once per frame
    void Update()
    {
        
    }

    void LocalGetHit()
    {
        CameraShake.Shake();
        
    }

    public static void GetHit()
    {
        instance.LocalGetHit();
    }
}
