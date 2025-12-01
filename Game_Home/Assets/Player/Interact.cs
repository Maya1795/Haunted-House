using UnityEngine;

public class Interact : MonoBehaviour
{
    [Tooltip("How far the player can reach")]
    public float interactRange = 3f;
    [Tooltip("Layer mask for interactable objects (set to Interactable layer)")]
    public LayerMask interactLayer;
    [Tooltip("UI prompt GameObject (optional)")]
    public GameObject uiPrompt;

    Camera cam;
    IInteractable currentInteractable;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (cam == null) Debug.LogWarning("Interact script should be attached to the Camera.");
        if (uiPrompt != null) uiPrompt.SetActive(false);
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        bool found = Physics.Raycast(ray, out hit, interactRange, interactLayer);
        if (found)
        {
            // Try to get the IInteractable on the hit collider
            currentInteractable = hit.collider.GetComponent<IInteractable>();
            if (currentInteractable != null)
            {
                if (uiPrompt != null) uiPrompt.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    currentInteractable.Interact();
                }
                return;
            }
        }

        // nothing found
        currentInteractable = null;
        if (uiPrompt != null) uiPrompt.SetActive(false);
    }
}
