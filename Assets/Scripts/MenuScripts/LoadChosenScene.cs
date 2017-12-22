using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadChosenScene : MonoBehaviour {
    public void loadNextScene(string nextScene) {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
    }
}
