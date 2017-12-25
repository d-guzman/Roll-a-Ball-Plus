using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerUI : MonoBehaviour {
    [Tooltip("Displays the player's score.")]
    public UnityEngine.UI.Text scoreText;
    [Tooltip("Displays how many lives the player has.")]
    public UnityEngine.UI.Text livesText;
    public UnityEngine.UI.Text gameOverText;
    public UnityEngine.UI.Button mainMenuButton;
    public UnityEngine.UI.Button quitGameButton;

    private int playerScore;
    private PlayerController playerObj;

    private bool gameIsOver = false;

    void Start() {
        playerObj = transform.GetComponent<PlayerController>();
    }

	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + playerObj.playerScore;
        livesText.text = "Lives: " + playerObj.playerLives;

        // Horribly inefficient. This is always called every frame.
        if (!gameIsOver) {
            if (playerObj.gamePaused) {
                gameOverText.text = "Game Paused.";
                gameOverText.gameObject.SetActive(true);
                mainMenuButton.gameObject.SetActive(true);
                quitGameButton.gameObject.SetActive(true);
            }
            else {
                gameOverText.text = "Game Over!";
                gameOverText.gameObject.SetActive(false);
                mainMenuButton.gameObject.SetActive(false);
                quitGameButton.gameObject.SetActive(false);
            }
        }

        if (playerObj.playerLives == -1) {
            gameIsOver = true;
            gameOverText.gameObject.SetActive(true);
            mainMenuButton.gameObject.SetActive(true);
            quitGameButton.gameObject.SetActive(true);
        }
	}
}
