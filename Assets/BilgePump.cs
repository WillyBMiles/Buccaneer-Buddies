using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BilgePump : Interactable
{
    public Animator animator;
    bool heldLastFrame = false;
    protected override void OnHoldDown(PlayerControls pc)
    {
        base.OnHoldDown(pc);
        WaterScript.Heal();
        heldLastFrame = true;
    }

    private void LateUpdate()
    {
        if (heldLastFrame)
        {
            animator.SetBool("Pump", true);
        }
        else
        {
            animator.SetBool("Pump", false);
        }
        heldLastFrame = false;
    }

}
