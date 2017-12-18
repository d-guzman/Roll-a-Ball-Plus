using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerUI : MonoBehaviour {
    [Tooltip("Displays the player's score.")]
    public UnityEngine.UI.Text scoreText;
    [Tooltip("Displays how many lives the player has.")]
    public UnityEngine.UI.Text livesText;

    private int playerScore;
    private PlayerController playerObj;

    void Start() {
        playerObj = transform.GetComponent<PlayerController>();
    }

	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + playerObj.playerScore;
        livesText.text = "Lives: " + playerObj.playerLives;
	}
}
