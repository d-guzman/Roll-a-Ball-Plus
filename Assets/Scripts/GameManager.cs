using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
    [SerializeField]
    private int GM_playerScore = 0;
    [SerializeField]
    private int GM_playerLives = 3;

    private GameObject GM_player = null;
    private PlayerController GM_playerCon = null;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode) {
        // This is where the data for the player will be transferred from scene to scene.
        // Unknown if this is good practice; more research is required.
        if (instance == this) {                                                // as i understand it, if this gm is the original instance, run code.
            if (scene.buildIndex != 0)
            {
                GM_player = GameObject.FindGameObjectWithTag("Player");        // Find the player in the scene.
                GM_playerCon = GM_player.GetComponent<PlayerController>();     // Get the PlayerController script from the player in the scene.

                GM_playerCon.playerScore = GM_playerScore;                     // Set the values in the script to the values in the GM.
                GM_playerCon.playerLives = GM_playerLives;
            }
            else if (scene.buildIndex == 0)
            {
                GM_playerScore = 0;                                            // Reset values if the player goes back to main menu.
                GM_playerLives = 3;
                GM_player = null;
                GM_playerCon = null;
            }
        }
    }

    void Update() {
        if (GM_playerCon != null) {
            GM_playerScore = GM_playerCon.playerScore;                     // Update Score and Lives as the player plays.
            GM_playerLives = GM_playerCon.playerLives;
        }
    }
}
