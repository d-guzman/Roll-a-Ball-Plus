﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [Tooltip("playerSpeed sets the acceleration and affects top speed.")]
    public float playerSpeed;
    [Tooltip("maxSpeed sets a hard limit on how quickly the player can move.")]
    public float maxSpeed;
    [Tooltip("Set this to the main camera so the player moves relative to the camera.")]
    public Camera mainCamera;
    [Tooltip("playerLives sets how many time the player can fall off before they get a game over.")]
    public int playerLives;
    [Tooltip("playerScore keeps track of the player's score in the game.")]
    public int playerScore;

    private float moveHori;
    private float moveVert;
    private Vector3 movement;

    private Rigidbody rb;
    private Vector3 startingPosition;

    public bool gamePaused = false;
    private Vector3 savedMovement;

    void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        startingPosition = transform.position;
	}

    void FixedUpdate() {
        // This would be a move function.
        moveHori = Input.GetAxis("Horizontal");
        moveVert = Input.GetAxis("Vertical");

        if (!gamePaused) { move(moveHori, moveVert); }
	}
    //Public Functions
    public void onPausePressed() {
        if (!gamePaused)
        {
            gamePaused = true;
            savedMovement = rb.velocity;
            rb.freezeRotation = true;
            rb.useGravity = false;
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, 0f);
        }
        else if (gamePaused) {
            gamePaused = false;
            rb.freezeRotation = false;
            rb.useGravity = true;
            rb.velocity = savedMovement;
        }
    }
    
    //Private Functions
    private void move(float moveHori, float moveVert) {
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
        }
    }

    //Other Unity Function Stuff.
    void OnTriggerEnter(Collider other) {
        if (other.tag == "Collectible") {
            playerScore += 100;
            other.gameObject.SetActive(false);
        }

        else if (other.tag == "KillPlane") {
            playerLives--;

            if (playerLives > -1) {
                rb.freezeRotation = true;
                rb.velocity = Vector3.ClampMagnitude(rb.velocity, 0f);
                transform.position = startingPosition;
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                rb.freezeRotation = false;
            }
            
            playerScore -= 250;
            if (playerScore < 0) {
                playerScore = 0;
            }
        }

        else if (other.tag == "FinishLine") {
            string nextScene = other.GetComponent<FinishLineScript>().SceneName;
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
        }
    }
}
