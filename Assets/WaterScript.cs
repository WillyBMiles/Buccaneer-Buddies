using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterScript : MonoBehaviour
{
    public float maxY = -5;
    public float minY = -8.75f;
    public float currentHealth = 100f;

    public float lossPerSecondPerLeak;
    public float regainPerSecond;

    public string LoseScene;

    static WaterScript instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        var list = FindObjectsOfType<FixInteractable>();
        if (list.Length > 0)
        {
            currentHealth -= list.Length * lossPerSecondPerLeak * Time.deltaTime;
            if (list.Length > 5)
                currentHealth -= (list.Length - 5) * lossPerSecondPerLeak * Time.deltaTime;
        }

        transform.position = new Vector3(0f, Mathf.Lerp(maxY, minY, currentHealth / 100f));

        if (currentHealth <= 0f)
        {
            SceneManager.LoadScene(LoseScene);
        }
    }

    public static void Heal()
    {
        instance.currentHealth += Time.deltaTime * instance.regainPerSecond;
        if (instance.currentHealth > 100f)
            instance.currentHealth = 100f;
    }
}
