using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputManager))]
public class PlayerInputManager_Manager : MonoBehaviour
{
    PlayerInputManager pim;

    private void Awake()
    {
        pim = GetComponent<PlayerInputManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            OnJoinAlt();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnJoinStandard();
        }
    }

    PlayerInput playerAlt;
    PlayerInput playerStandard;
    void OnJoinAlt()
    {
        if (playerAlt == null)
        {
            string controlScheme = "KeyboardAlt";
            InputDevice device = Keyboard.current;
            playerAlt = PlayerInput.Instantiate(pim.playerPrefab, controlScheme: controlScheme, pairWithDevice: device);
            playerAlt.SwitchCurrentControlScheme(controlScheme, device);
        }

    }
    void OnJoinStandard()
    {
        if (playerStandard == null)
        {
            string controlScheme = "Keyboard";
            InputDevice device = Keyboard.current;
            playerStandard = PlayerInput.Instantiate(pim.playerPrefab, controlScheme: controlScheme, pairWithDevice: device);
            playerStandard.SwitchCurrentControlScheme(controlScheme, device);
        }
    }
}
