using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;

public class UIManagerLevelSelect : MonoBehaviour
{   
    public string mainMenu;

    private void Awake()
    {
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void MainMenu2() {
        SceneManager.LoadScene(mainMenu);
    }
}
