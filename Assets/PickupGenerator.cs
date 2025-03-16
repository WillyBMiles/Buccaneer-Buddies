using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGenerator : Interactable
{

    public Pickup pickup;
    protected override void OnInteract(PlayerControls pc)
    {
        base.OnInteract(pc);
        if (pc.holding != null)
            return;
        Pickup p = Instantiate(pickup);
        p.heldBy = pc;
        pc.holding = p;
    }
}
