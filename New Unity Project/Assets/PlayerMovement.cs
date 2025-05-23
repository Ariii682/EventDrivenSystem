using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody rb;

    private Vector3 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        moveInput = new Vector3(moveX, 0f, moveZ) * moveSpeed;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * Time.fixedDeltaTime);
    }
}
