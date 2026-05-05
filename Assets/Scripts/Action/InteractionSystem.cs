using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class InteractionSystem : MonoBehaviour
{
    [Header("Interaction")]
    [SerializeField] float interactionRange = 2.5f;
    [SerializeField] LayerMask interactableLayer;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI interactPrompt;

    [Header("Camera")]
    [SerializeField] Camera playerCamera;
    
    IInteractable currentInteractable;

    private void Update()
    {
        CheckForInteractable();

        if (Keyboard.current.eKey.wasPressedThisFrame && currentInteractable != null)
            currentInteractable.Interact();
    }

    void CheckForInteractable()
    {
        // safety check
        if (playerCamera == null) return;

        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionRange, interactableLayer))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                currentInteractable = interactable;
                interactPrompt.gameObject.SetActive(true);
                return;
            }
        }

        currentInteractable = null;
        interactPrompt.gameObject.SetActive(false);
    }
}