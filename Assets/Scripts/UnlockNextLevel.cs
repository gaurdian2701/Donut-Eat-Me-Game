using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockNextLevel : MonoBehaviour
{
    public int levelToUnlock;
    int numberOfUnlockedLevels;

    public void unlockNext() {
        numberOfUnlockedLevels = PlayerPrefs.GetInt("levelsUnlocked");

        if(numberOfUnlockedLevels <= levelToUnlock) {
            PlayerPrefs.SetInt("levelsUnlocked", numberOfUnlockedLevels+1);
        }
    }
}
