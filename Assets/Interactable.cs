using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public enum InteractType
    {
        Press,
        Hold,
        Lock
    }

    public InteractType type;
    static readonly Dictionary<PlayerControls, List<Interactable>> nearby = new();

    public PlayerControls currentInteraction;
    static readonly Dictionary<PlayerControls, Interactable> currentInteractions = new();

    public GameObject interactionPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentInteraction != null && type == InteractType.Hold)
        {
            OnHoldDown(currentInteraction);
        }
    }

    public void Interact(PlayerControls pc)
    {
        if (currentInteraction != null && currentInteraction != pc)
            return;
        if (currentInteractions.ContainsKey(pc) && currentInteractions[pc] != this)
            return;

        switch (type)
        {
            case InteractType.Press:
                Debug.Log($"{gameObject.name}, Interact by {pc.gameObject.name}");
                OnInteract(pc);
                break;
            case InteractType.Hold:
                //PASS
                break;
            case InteractType.Lock:
                Debug.Log($"{gameObject.name}, Lock by {pc.gameObject.name}");
                currentInteraction = pc;
                currentInteractions[pc] = this;
                break;
        }
    }

    protected virtual void OnInteract(PlayerControls pc)
    {

    }

    public void HoldInteract(PlayerControls pc)
    {
        if (type != InteractType.Hold)
            return;

        if (currentInteraction != null && currentInteraction != this)
            return;
        if (currentInteractions.ContainsKey(pc) && currentInteractions[pc] != this)
            return;

        Debug.Log($"{gameObject.name}, Hold by {pc.gameObject.name}");
        currentInteraction = pc;
        currentInteractions[pc] = this;

        
    }

    protected virtual void OnHoldDown(PlayerControls pc)
    {

    }

    private void OnDestroy()
    {
        ReleaseHoldInteract(currentInteraction);
        InternalCancel(currentInteraction);
    }
    public void ReleaseHoldInteract(PlayerControls pc)
    {
        if (type != InteractType.Hold)
            return;
        if (pc == null)
            return;
        if (currentInteraction != null && currentInteraction != pc)
            return;
        if (currentInteractions.ContainsKey(pc) && currentInteractions[pc] != this)
            return;
        InternalCancel(pc);

    }


    public void CancelInteraction(PlayerControls pc)
    {
        if (type != InteractType.Lock)
            return;
        InternalCancel(pc);
    }

    void InternalCancel(PlayerControls pc)
    {
        if (pc == null)
            return;
        if (currentInteraction != null && currentInteraction != pc)
            return;
        if (currentInteractions.ContainsKey(pc) && currentInteractions[pc] != this)
            return;
        currentInteraction = null;
        currentInteractions.Remove(pc);
    }

    public virtual void PassInput(Vector2 move)
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerControls pc = collision.gameObject.GetComponent<PlayerControls>();
        if (pc != null)
        {
            if (!nearby.ContainsKey(pc) || nearby[pc] == null)
            {
                nearby[pc] = new();
            }
            nearby[pc].Add( this);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerControls pc = collision.gameObject.GetComponent<PlayerControls>();
        if (pc != null && nearby.ContainsKey(pc))
        {
            nearby[pc].Remove(this);
        }
    }

    public static Interactable Nearest(PlayerControls pc)
    {
        if (nearby.ContainsKey(pc))
        {

            Interactable best = null;
            float dist = Mathf.Infinity;
            foreach (Interactable interactable in nearby[pc])
            {
                float thisDist = Vector2.Distance(interactable.transform.position, pc.transform.position);
                if (thisDist < dist)
                {
                    best = interactable;
                    dist = thisDist;
                }
            }

            return best;
        }
        return null;
    }

    public static Interactable Interacting(PlayerControls pc)
    {
        if (currentInteractions.ContainsKey(pc))
        {
            return currentInteractions[pc];
        }
        return null;
    }

}
