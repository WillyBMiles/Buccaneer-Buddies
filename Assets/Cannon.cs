using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : Interactable
{
    public bool loaded = true;
    public bool left = false;

    public Animator animator;

    [SerializeField]
    ShipMovement shipMovement;

    private void LateUpdate()
    {
        animator.SetBool("Left", !left);
    }
    protected override void OnInteract(PlayerControls pc)
    {
        base.OnInteract(pc);
        if (loaded)
        {
            animator.SetTrigger("Fire"); 
            StartCoroutine(nameof(Fire));
        }
            
        else
        {
            if (pc.holding != null && pc.holding.pickupType == Pickup.PickupType.Cannonball)
            {
                
                GameObject.Destroy(pc.holding.gameObject);
                pc.holding = null;
                loaded = true;
                animator.SetTrigger("Load");
            }
        }
    }

    public IEnumerator Fire()
    {
        yield return new WaitForSeconds(.25f);
        if (loaded)
        {
            
            shipMovement.Shoot(left);
            loaded = false;
        }

    }
}
