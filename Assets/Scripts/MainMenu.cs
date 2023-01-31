using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string firstLevel, levelSelect;
    public GameObject continueButton;

    public EnvSoundManager envSounds;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("Continue")) {
            continueButton.SetActive(true);
        }
        envSounds = GameObject.Find("Env").GetComponent<EnvSoundManager>();
        envSounds.PlayMenuMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame() {
        SceneManager.LoadScene(firstLevel);
        PlayerPrefs.SetInt("Continue", 0);
    }

    public void Continue() {
        SceneManager.LoadScene(levelSelect);
    }

    public void QuitGame() {
        envSounds.StopMusic();
        Application.Quit();
    }
}
