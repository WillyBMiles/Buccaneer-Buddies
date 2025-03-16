using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float time;
    public Ship origin;

    public bool player;

    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
        time -= Time.deltaTime;
        if (time <= 0f)
            Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (origin == null)
            return;
        Ship ship = collision.GetComponentInParent<Ship>();
       
        if (ship != null)
        {
            if (ship.gameObject == origin.gameObject)
                return;
            if (ship.isPlayer != player)
            {
                ship.TakeDamage();
                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(gameObject);
            }

        }
        else
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
    }

}
