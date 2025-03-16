using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltSprite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public float scaling;
    // Update is called once per frame
    void Update()
    {
        float verticalAngle = Vector2.SignedAngle(transform.parent.up, Vector2.up);
        float actualAngle;
        if (verticalAngle <= 0f)
        {
            transform.localScale= new Vector3(-1f, 1f, 1f);
            actualAngle = -Vector2.SignedAngle(transform.parent.up, -Vector3.right);
            transform.rotation = Quaternion.Euler(0f, 0f, (actualAngle / scaling));
        }
        else 
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            actualAngle = -Vector2.SignedAngle(transform.parent.up, Vector3.right);
            transform.rotation = Quaternion.Euler(0f, 0f, (actualAngle / scaling));
        }
    }
}
