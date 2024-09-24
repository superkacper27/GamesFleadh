using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoorInteractable : MonoBehaviour, IInteractable
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Interact()
    {
        doorInteract();
    }

    private void doorInteract() 
    {
        if (animator.GetBool("isOpen") == false)
        {
            animator.SetBool("isOpen", true);
        }
        else 
        {
            animator.SetBool("isOpen", false);
        }

    }

    public string GetInteractText()
    {
        return "Interact";
    }
}
