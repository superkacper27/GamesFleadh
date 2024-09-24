using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;

public class PlayerInteractUi : MonoBehaviour
{
    [SerializeField] private GameObject containerGameObject;
    [SerializeField] private PlayerInteract playerInteract;
    [SerializeField] private TextMeshProUGUI interactTextMeshProUGUI;
    [SerializeField] private GameObject volume;
    public TMP_FontAsset tmFont;
    public TMP_FontAsset infectFont;
    public NPCInteractable npcObject;
    private void Start()
    { 
    }

    private void Update()
    {
        if (playerInteract.GetInteractableObject() != null && npcObject.minigameOn == false) 
        {
            Show(playerInteract.GetInteractableObject());
        }
        else
        {
            Hide();
        }
    }
    private void Show(IInteractable interactable)
    {
        volume.SetActive(true);
        volume.GetComponent<Animator>().Play("bloodThirstAnimation");
        containerGameObject.SetActive(true);
        interactTextMeshProUGUI.text = interactable.GetInteractText();
        if (interactable.GetInteractText().Equals("Interact")) 
        {
            interactTextMeshProUGUI.fontSize = 86;
        } 
        else 
        {
            interactTextMeshProUGUI.font = infectFont;
            interactTextMeshProUGUI.fontSize = 96;
        }
    }

    private void Hide()
    {
        containerGameObject.SetActive(false);
    }
}
