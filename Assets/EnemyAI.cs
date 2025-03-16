using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    ShipMovement shipMove;
    Ship ship;

    private void Awake()
    {
        shipMove = GetComponent<ShipMovement>();
        ship = GetComponent<Ship>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }


    float timer;
    // Update is called once per frame
    void Update()
    {
        if (timer  < 0f )
        {
            shipMove.Shoot(Random.value < .5f ? true : false);
            timer = Random.value * 3f + .35f;
        }
        timer -= Time.deltaTime;


        
    }
}
