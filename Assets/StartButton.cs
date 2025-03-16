using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

    private void Start()
    {
        TreasureChest.score = 0f;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
