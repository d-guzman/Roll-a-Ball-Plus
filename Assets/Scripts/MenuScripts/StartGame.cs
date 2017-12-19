using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {
    public void playGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Test_Level");
    }
}
