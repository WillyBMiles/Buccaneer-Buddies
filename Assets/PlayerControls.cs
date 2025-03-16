using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControls : MonoBehaviour
{
    public float speedMultiplier;
    CharacterController2D controller;
    Rigidbody2D rb;
    public Animator animator;
    public Pickup holding;
    public GameObject holdOffset;

    public RuntimeAnimatorController secondaryController;

    public Color baseColor;

    static int player = 0;
    private void Awake()
    {
        controller = GetComponent<CharacterController2D>();
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        player++;
        if (player % 2 == 0)
        {
            animator.runtimeAnimatorController = secondaryController;
        }
    }

    bool holdInteract;
    float movement;
    bool jump;

    Vector2 shipMovement;
    
    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Fixing", false);
        animator.SetBool("Driving", false);

        Interactable currentInteraction = Interactable.Interacting(this);

        if (holdInteract)
        {
            Interactable interactable = Interactable.Nearest(this);
            if (interactable != null)
            {
                interactable.HoldInteract(this);

                if (interactable is FixInteractable fixable)
                {
                    if (fixable.hasPlacedLog)
                    {
                        animator.SetBool("Fixing", true);
                        animator.speed = 1f;
                    }
                    
                }
                if (interactable is BilgePump)
                {
                    animator.SetBool("Driving", true);
                }
            }
                
        }
        else if (currentInteraction != null)
        {
            currentInteraction.ReleaseHoldInteract(this);
        }



        if (currentInteraction != null)
        {
            rb.isKinematic = true;
            transform.position = currentInteraction.interactionPoint.transform.position;
            if (controller.m_FacingRight)
                controller.Flip();
            currentInteraction.PassInput(shipMovement);
            if (currentInteraction is WheelInteractable)
            {
                animator.SetBool("Driving", true);
            }
            
        }
        else
        {
            controller.Move(movement, jump);
            jump = false;
            rb.isKinematic = false;
            bool moving = Mathf.Abs(rb.velocity.x) > .5f;
            animator.SetBool("Walking", moving);
            if (moving)
                animator.speed = Mathf.Abs(rb.velocity.x) / (15f * speedMultiplier);
            else
                animator.speed = 1f;
        }

        
        if (holding!= null)
        {
            animator.SetBool("Hold", true);
        }
        else
        {
            animator.SetBool("Hold", false);
        }

        /*
        if (rb.velocity.x < 0f)
        {
            animator.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (rb.velocity.x > 0f)
        {
            animator.transform.localScale = new Vector3(1f, 1f, 1f);
        }*/
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        movement = speedMultiplier * context.ReadValue<float>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //jump = context.action.triggered;
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.action.triggered)
        {
            Interactable interactable = Interactable.Nearest(this);
            if (interactable != null)
            {
                interactable.Interact(this);
            }
            if ((holding != null && holding != interactable ) && !(interactable is PickupGenerator))
            {
                holding.heldBy = null;
                holding = null;
            }
        }
        holdInteract = context.action.IsPressed();
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        if (context.action.triggered)
        {
            Interactable interactable = Interactable.Interacting(this);
            if (interactable != null && interactable.currentInteraction == this)
            {
                interactable.CancelInteraction(this);
            }
        }
    }

    public void OnShipMovement(InputAction.CallbackContext context)
    {
        shipMovement  = context.ReadValue<Vector2>();
        if (shipMovement.y > .5f)
        {
            jump = true;
        }

        
    }

}
