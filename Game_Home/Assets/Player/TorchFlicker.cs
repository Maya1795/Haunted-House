using UnityEngine;

public class TorchFollowPlayer : MonoBehaviour
{
    public Transform cameraTransform; // MainCamera
    public Vector3 handOffset = new Vector3(0.3f, 1.0f, 0.5f);

    void LateUpdate()
    {
        if (cameraTransform != null)
        {
            // Position torch relative to the camera
            transform.position = cameraTransform.position + cameraTransform.TransformDirection(handOffset);

            // Rotate torch to match camera's forward direction
            transform.rotation = cameraTransform.rotation;
        }
    }
}
