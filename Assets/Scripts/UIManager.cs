using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject pauseScreen, settingsScreen, deathScreen, victoryScreen;
    
    private PlayerActionAsset donutActionAsset;
    private InputAction move;

    public string levelSelect, mainMenu;
    private Scene scene;

    public int levelToUnlock;
    int numberOfUnlockedLevels;

    private GameObject[] enemies;

    public EnvSoundManager envSounds;

    private void Awake()
    {
        donutActionAsset = new PlayerActionAsset();
        move = donutActionAsset.Player.Move;
        donutActionAsset.Player.Enable();
    }

    void Start()
    {
        scene = SceneManager.GetActiveScene();
        enemies = GameObject.FindGameObjectsWithTag ("Enemy");
        envSounds = GameObject.Find("Env").GetComponent<EnvSoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Assert.IsNotNull(pauseScreen);
        donutActionAsset.Player.Pause.started += PauseUnpauseGame;

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length <= 0)
        {
            VictoryScreen();
            unlockNext();
        }
    }

    public void unlockNext() {
        numberOfUnlockedLevels = PlayerPrefs.GetInt("levelsUnlocked");

        if(numberOfUnlockedLevels <= levelToUnlock) {
            PlayerPrefs.SetInt("levelsUnlocked", numberOfUnlockedLevels+1);
        }
    }

    private void PauseUnpauseGame(InputAction.CallbackContext obj)
    {
        if(pauseScreen.activeInHierarchy) {
            envSounds.ResumeMusic();
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
        else {
            envSounds.PauseMusic();
            pauseScreen.SetActive(true);
            CloseSettings();
            Time.timeScale = 0f;
        }
    }

    private void VictoryScreen() {
        victoryScreen.SetActive(true);
        envSounds.StopMusic();
    }

    private void PauseUnpauseGame2()
    {
        if(pauseScreen.activeInHierarchy) {
            envSounds.ResumeMusic();
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
        }
        else {
            envSounds.PauseMusic();
            pauseScreen.SetActive(true);
            CloseSettings();
            Time.timeScale = 0f;
        }
    }

    public void Resume() {
        PauseUnpauseGame2();
    }

    public void OpenSettings() {
        settingsScreen.SetActive(true);
    }

    public void CloseSettings() {
        settingsScreen.SetActive(false);
    }

    public void LevelSelect() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(levelSelect);
    }

    public void MainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenu);
    }

    public void SetMusicLevel() {

    }

    public void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene < 15)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void DeathScreen() {
        envSounds.StopMusic();
        deathScreen.SetActive(true);
        Time.timeScale = 0.25f;
    }

    public void restart() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene.name);
    }
}
