using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearWhen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TreasureChest.score > 0f)
            Destroy(gameObject);
    }
}
