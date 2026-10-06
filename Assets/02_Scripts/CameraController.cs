using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("InputReader")]
    [SerializeField] private InputReader inputReader;

    [Header("Target")]
    [SerializeField] private Transform playerTransform;

    // 카메라 관련 변수
    private Transform cameraRig;
    private Camera mainCamera;

    [Header("Zoom")]
    [SerializeField] private float zoomSpeed = 0.01f;
    [SerializeField] private float minZoom = 1f;
    [SerializeField] private float maxZoom = 4f;

    private void Awake()
    {
        cameraRig = GetComponent<Transform>();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        inputReader.OnZoomRequested += HandleZoom;
    }

    private void OnDisable()
    {
        inputReader.OnZoomRequested -= HandleZoom;
    }

    private void LateUpdate()
    {
        cameraRig.position = playerTransform.position;
    }

    private void HandleZoom(float zoomValue)
    {
        // Orthographic 카메라 줌 처리
        float zoomDirection = Mathf.Sign(zoomValue);
        float nextSize = mainCamera.orthographicSize - zoomSpeed * zoomDirection;

        mainCamera.orthographicSize = Mathf.Clamp(nextSize, minZoom, maxZoom);
    }
}
