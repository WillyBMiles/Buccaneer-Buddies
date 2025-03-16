using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    static CameraShake instance;
    public float time;
    public float amount;
    Vector3 initialPosition;

    public static void Shake()
    {
        instance.shakeTimeRemaining = instance.time;
    }

    float shakeTimeRemaining;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.localPosition;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeTimeRemaining > 0f)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere * amount * (shakeTimeRemaining / time);
            shakeTimeRemaining -= Time.deltaTime;
        }
        else
        {
            transform.localPosition = initialPosition;
        }
    }
}
