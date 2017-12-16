using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float playerSpeed;
    public float maxSpeed = 10.0f;
    public Camera mainCamera;

    private float moveHori;
    private float moveVert;
    private Vector3 movement;

    private Rigidbody rb;

    void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        
	}

    void FixedUpdate() {
        // This would be a move function.
        moveHori = Input.GetAxis("Horizontal");
        moveVert = Input.GetAxis("Vertical");

        if (moveVert != 0.0f || moveHori != 0.0f)
        {
            Vector3 camForward = mainCamera.transform.forward;
            Vector3 camRight = mainCamera.transform.right;

            camForward.y = 0.0f;
            camRight.y = 0.0f;
            camForward.Normalize();
            camRight.Normalize();

            movement = camForward * moveVert + camRight * moveHori;
            rb.AddForce(movement * playerSpeed, ForceMode.Impulse);                              
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
            Debug.Log("Speed: " + rb.velocity.magnitude);

        }
	}
}
