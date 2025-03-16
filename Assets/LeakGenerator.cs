using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LeakGenerator : MonoBehaviour
{
    static LeakGenerator instance;
    public List<GameObject> leakLocations = new();
    Dictionary<GameObject, GameObject> leaks = new();

    public GameObject LeakPrefab;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var g in leaks.Keys.ToList())
        {
            if (leaks[g] == null)
            {
                leaks.Remove(g);
            }
        }
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.F1))
            GenerateLeak();
#endif
    }

    void LocalGenerateLeak()
    {
        InteriorShipController.GetHit();
        if (leakLocations.Count == leaks.Count)
        {
            //Too many leaks! No room
            return;
        }
        GameObject leakLocation;
        do
        {
            leakLocation = leakLocations[Random.Range(0, leakLocations.Count)];


        } while (leaks.ContainsKey(leakLocation));
        GameObject newLeak = Instantiate(LeakPrefab, transform.parent);
        newLeak.transform.position = leakLocation.transform.position;
        newLeak.transform.rotation = leakLocation.transform.rotation;
        leaks[leakLocation] = newLeak;
    }
    public static void GenerateLeak() {
        instance.LocalGenerateLeak();
    }
}
