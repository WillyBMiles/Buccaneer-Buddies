using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public bool isPlayer;
    ShipMovement sm;

    public int damageTaken;
    public int health;

    public GameObject explosion;

    public bool destroyParent = false;

    public GameObject dropOnDeath;
    // Start is called before the first frame update
    void Start()
    {
        sm = GetComponent<ShipMovement>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (damageTaken >= health)
        {
            if (dropOnDeath)
            Instantiate(dropOnDeath, transform.position, Quaternion.identity);
            Destroy(gameObject);
            if (destroyParent)
            {
                Destroy(transform.parent.gameObject);
            }
            Instantiate(explosion, transform.position + (Vector3) Random.insideUnitCircle, transform.rotation);
            Instantiate(explosion, transform.position + (Vector3)Random.insideUnitCircle, transform.rotation);
            Instantiate(explosion, transform.position + (Vector3)Random.insideUnitCircle, transform.rotation);
        }
    }

    public void TakeDamage()
    {
        //TODO
        if (!isPlayer)
            damageTaken++;
        sm.GenerateDamage();
    }
}
