using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScore : MonoBehaviour {
    [Tooltip("Link the player score to the score text object in the UI.")]
    public UnityEngine.UI.Text scoreText;

    [SerializeField]
    private int playerScore;

	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + playerScore;
	}

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Collectible") {
            playerScore += 100;
            other.gameObject.SetActive(false);
        }
    }
}
