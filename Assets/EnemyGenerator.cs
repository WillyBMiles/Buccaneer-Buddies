using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<SplineContainer> possibleSplines = new();

    public bool testGenerate = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    float currentTime;
    float time = 17f;
    // Update is called once per frame
    void Update()
    {
        if (testGenerate)
        {
            testGenerate = false;
            Create();
        }

        if (FindObjectsOfType<PlayerControls>().Length == 0)
            return;

        if (currentTime <= 0f)
        {
            if (FindObjectsOfType<EnemyAI>().Length > 14)
                return;
            Create();
            time *= .95f;
            currentTime = time;
        }
        currentTime -= Time.deltaTime;


#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.C))
        {
            Create();
        }
#endif
    }

    public void Create()
    {
        GameObject enemy = Instantiate(enemyPrefab);
        SplineAnimate sa = enemy.GetComponent<SplineAnimate>();
        sa.StartOffset = Random.value;
        sa.Container = possibleSplines[Random.Range(0, possibleSplines.Count)];
    }
}
