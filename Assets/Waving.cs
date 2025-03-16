using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waving : MonoBehaviour
{

    public float tOffset;
    public float tScale;
    public float yAmplitude;
    public float xAmplitude;
    Vector3 startingPosition;

    float t;
    // Start is called before the first frame update
    void Start()
    {
        t = tOffset;
        startingPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = startingPosition + Vector3.up * Mathf.Sin(t) * yAmplitude + Vector3.right * Mathf.Cos(t) * xAmplitude;
        t += tScale * Time.deltaTime;
    }
}
