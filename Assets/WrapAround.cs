using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapAround : MonoBehaviour
{
     float leftEdge = -35.5f;
     float rightEdge = 35.5f;
     float topEdge = 11.5f;
     float bottomEdge = -11.5f;

    Rigidbody2D rb2d;
    ShipMovement shipMovement;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        shipMovement = GetComponent<ShipMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x < leftEdge)
        {
            float dif = transform.position.x - leftEdge; 

            transform.position =  new Vector3(rightEdge, transform.position.y + dif);
            if (rb2d)
                rb2d.position = transform.position;
            if (shipMovement)
            {
                shipMovement.lastPosition = transform.position;
            }
        }
        if (transform.position.x > rightEdge)
        {
            float dif = transform.position.x - rightEdge;

            transform.position = new Vector3(leftEdge, transform.position.y + dif);
            if (rb2d)
                rb2d.position = transform.position;
            if (shipMovement)
            {
                shipMovement.lastPosition = transform.position;
            }

        }

        if (transform.position.y > topEdge)
        {
            float dif = transform.position.y - topEdge;

            transform.position = new Vector3(transform.position.x + dif, bottomEdge);
            if (rb2d)
                rb2d.position = transform.position;
            if (shipMovement)
            {
                shipMovement.lastPosition = transform.position;
            }
        }

        if (transform.position.y < bottomEdge)
        {
            float dif = transform.position.y - bottomEdge;

            transform.position = new Vector3(transform.position.x + dif, topEdge);
            if (rb2d)
                rb2d.position = transform.position;
            if (shipMovement)
            {
                shipMovement.lastPosition = transform.position;
            }
        }

    }
}
