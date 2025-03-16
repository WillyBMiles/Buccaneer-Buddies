using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixInteractable : Interactable
{
    public bool hasPlacedLog = false;
    public Animator animator;
    public float fixNeeded = 1f;

    float fixAmount;

    private void LateUpdate()
    {
        
    }
    protected override void OnInteract(PlayerControls pc)
    {
        base.OnInteract(pc);

        if (!hasPlacedLog)
        {
            if (pc.holding != null && pc.holding.pickupType == Pickup.PickupType.Wood)
            {

                GameObject.Destroy(pc.holding.gameObject);
                pc.holding = null;
                hasPlacedLog = true;
                animator.SetTrigger("Log");
                type = InteractType.Hold;
            }
        }
    }

    protected override void OnHoldDown(PlayerControls pc)
    {
        base.OnHoldDown(pc);
        if (hasPlacedLog)
        {
            fixAmount += Time.deltaTime;
            if (fixAmount > fixNeeded)
            {
                Destroy(gameObject);
            }
        }
    }

}
