using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void LoadSceneOnClick(int sceneNum) {
        SceneManager.LoadScene(sceneNum);
    }

    public void LoadSceneOnClick(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSceneOnClick(Scene scene) {
        SceneManager.LoadScene(scene.name);
    }
}
