using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlock : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    int unlockedLevelsNumber;

    void Start()
    {
        if(!PlayerPrefs.HasKey("levelsUnlocked")) {
            PlayerPrefs.SetInt("levelsUnlocked", 1);
        }

        unlockedLevelsNumber = PlayerPrefs.GetInt("levelsUnlocked");
        
        for(int i = 0; i < buttons.Length; i++) {
            buttons[i].interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        unlockedLevelsNumber = PlayerPrefs.GetInt("levelsUnlocked");
        for(int i =0; i < 15; i++) {
            buttons[i].interactable = true;

        }
    }
}
