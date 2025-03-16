using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

[RequireComponent(typeof(Ship))]
public class ShipMovement : MonoBehaviour
{
    public float maxRotationSpeed;
    public float rotationSmooth;

    public float maxSpeed;
    public float speedSmooth;

    public float straightenSmooth;
    Rigidbody2D rb;
    Ship ship;


    public Vector2 actualVelocity { get; private set; }
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ship = GetComponent<Ship>();
        lastPosition = transform.position;
    }

    public Vector2 lastPosition;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.isKinematic)
            return;

        actualVelocity = ((Vector2)transform.position - lastPosition) / Time.fixedDeltaTime;
        lastPosition = transform.position;
        rb.velocity = speed * transform.up;// Vector2.Lerp(rb.velocity, speed*transform.up, straightenSmooth *Time.deltaTime);
        //Debug.Log($"RBVelocity: {rb.velocity} | ActualVelocity: {actualVelocity} | speed: {speed} |  upwards dot: {Vector2.Dot(transform.up, actualVelocity)}");
    }

    private void LateUpdate()
    {
        
    }
    public void Move(Vector2 move)
    {
        if (move.y < 0)
            move.y /= 4;
        speed = Mathf.Lerp(Vector2.Dot(transform.up,actualVelocity), move.y* maxSpeed, speedSmooth * Time.deltaTime);
        
        rb.angularVelocity = Mathf.Lerp(rb.angularVelocity, -move.x * maxRotationSpeed, rotationSmooth * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.sqrMagnitude > .2f)
        {
            GenerateDamage();
        }
    }

    public void GenerateDamage()
    {
        if (ship.isPlayer)
            LeakGenerator.GenerateLeak();
        else
        {

        }
    }
    [SerializeField]
    Projectile projectile;
    public void Shoot(bool left)
    {
        Vector2 direction = left ? -transform.right : transform.right;
        Projectile p  = Instantiate(projectile, transform.position, Quaternion.identity);
        p.transform.up = direction;
        p.origin = ship;
    }
}
