using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable
{
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public Collider2D defaultCollider;
    public Rigidbody2D rb;
    public PlayerControls heldBy;
    public PickupType pickupType;

    public enum PickupType { 
        Cannonball,
        Wood
    }
    protected override void OnInteract(PlayerControls pc)
    {
        base.OnInteract(pc);
        if (heldBy == null && pc.holding == null)
        {
            heldBy = pc;
            pc.holding = this;
        }
        else if (heldBy == pc && pc.holding == this)
        {
            heldBy = null;
            pc.holding = null;
        }
    }

    protected void OnPickUpInteract()
    {

    }

    private void LateUpdate()
    {
        if (heldBy != null)
        {
            transform.position = heldBy.holdOffset.transform.position;
            rb.isKinematic = true;
            defaultCollider.enabled = false;
            rb.angularVelocity = 0f;
            transform.rotation = Quaternion.identity;
        }
        else
        {
            rb.isKinematic = false;
            defaultCollider.enabled = true;
        }
        
    }

}
