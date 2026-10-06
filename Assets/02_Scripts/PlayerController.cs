using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public InputReader inputReader;

    [SerializeField] private float moveSpeed = 3f;

    private Rigidbody rb;
    private Transform playerTransform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerTransform = transform;
    }

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        Vector2 inputDirection = inputReader.MoveDirection;

        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = inputDirection.x;
        moveDirection.z = inputDirection.y;

        if (moveDirection != Vector3.zero)
        {
            Vector3 lookTargetPosition = playerTransform.position + moveDirection;

            playerTransform.LookAt(lookTargetPosition);
        }

        rb.linearVelocity = moveDirection * moveSpeed;
    }
}
