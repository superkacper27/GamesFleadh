using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private infectedSO infectedScore;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

            foreach (Collider collider in colliderArray) 
            {
                if (collider.TryGetComponent(out IInteractable interactable))
                {
                        interactable.Interact();
                }
            }

        }

        if (infectedScore.Score >= 15f || Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

    public IInteractable GetInteractableObject()
    {
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);

        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out IInteractable interactable))
            {
                return interactable;
            }
        }
        return null;
    }

}
