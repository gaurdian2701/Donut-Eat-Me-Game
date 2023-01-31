using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelsButton : MonoBehaviour
{
    public int sceneIndex;

    public void OpenScene() {
        SceneManager.LoadScene(sceneIndex);
    }
}
