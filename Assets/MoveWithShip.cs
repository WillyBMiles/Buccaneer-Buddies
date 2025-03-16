using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithShip : MonoBehaviour
{
    public float minX;
    public float maxX;

    public float moveSpeedConversion;
    public ShipMovement ship;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x < minX || transform.position.x > maxX)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = Vector3.Dot(ship.actualVelocity, ship.transform.up) * moveSpeedConversion;
        transform.position = new Vector3(transform.position.x +moveSpeed * Time.deltaTime, transform.position.y, 0f);

        if (transform.position.x < minX)
        {
            transform.position = new Vector3(maxX - (minX- transform.position.x), transform.position.y);
        }

        if (transform.position.x > maxX)
        {
            transform.position = new Vector3(minX + (maxX - transform.position.x), transform.position.y);
        }
    }
}
