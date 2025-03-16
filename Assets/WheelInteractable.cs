using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelInteractable : Interactable
{
    public ShipMovement shipMovement;
    public override void PassInput(Vector2 move)
    {
        base.PassInput(move);
        shipMovement.Move(move);

    }
}
