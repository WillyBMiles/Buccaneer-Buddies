using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailSwap : MonoBehaviour
{
    public Sprite sailFlowing;
    public Sprite sailStill;
    public SpriteRenderer sr;

    public ShipMovement shipMovement;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Dot(shipMovement.transform.up, shipMovement.actualVelocity) > 0f)
        {
            sr.sprite = sailFlowing;
        }
        else
        {
            sr.sprite = sailStill;
        }
    }
}
