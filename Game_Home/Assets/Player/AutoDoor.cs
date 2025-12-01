using UnityEngine;

public class AutoRotateDoor : MonoBehaviour
{
    public float openAngle = 90f; // relative open angle
    public float speed = 2f;

    bool isOpen;
    float closedY;    // actual Y rotation when closed
    float targetY;    // target Y rotation for Update
    float currentAngle;

    private void Start()
    {
        // Store the door's current Y rotation as the closed rotation
        closedY = transform.localEulerAngles.y;
        currentAngle = closedY;
        targetY = closedY; // start closed
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpen = true;
            targetY = closedY + openAngle; // open relative to closed position
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOpen = false;
            targetY = closedY; // return to closed rotation
        }
    }

    private void Update()
    {
        // Smoothly rotate towards targetY
        currentAngle = Mathf.Lerp(currentAngle, targetY, Time.deltaTime * speed);
        transform.localRotation = Quaternion.Euler(0, currentAngle, 0);
    }
}

