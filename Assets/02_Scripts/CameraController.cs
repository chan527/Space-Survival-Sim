using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    private Transform cameraTransform;

    private void Awake()
    {
        cameraTransform = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        cameraTransform.position = playerTransform.position;
    }
}
