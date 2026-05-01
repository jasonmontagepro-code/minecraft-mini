using UnityEngine;

public class PlayerMovementUpgraded : MonoBehaviour
{
    [SerializeField] private float groundDrag = 5f;
    [SerializeField] private float airDrag = 2f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float groundDist = 0.2f;
    
    private Rigidbody rb;
    private PlayerStats playerStats;
    private bool isGrounded;
    private float xRotation = 0f;
    private Vector3 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerStats = GetComponent<PlayerStats>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        HandleMovement();
        HandleCamera();
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundDist);
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;
        moveDirection = moveDirection.normalized;

        float currentSpeed = playerStats.GetCurrentSpeed();
        rb.AddForce(moveDirection * currentSpeed, ForceMode.Acceleration);

        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVel.magnitude > currentSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * currentSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }

        rb.drag = isGrounded ? groundDrag : airDrag;
    }

    private void HandleCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
