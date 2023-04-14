using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "GameData", menuName = "ScriptableObjects/Game Data", order = 1)]
public class GameData : ScriptableObject
{
    [BoxGroup("Level")]
    public int fakeLevelIndex, realLevelIndex, levelLoopValue;
    [BoxGroup("Level/Tutorial")]
    public bool finiteTutorial;
    [BoxGroup("Level/Tutorial"), ShowIf("finiteTutorial")]
    public int tutorialLevelCount;


    [BoxGroup("Total Money")] public int totalMoneyAmount;
    


    //---------------------------------------------------------------------------------
    private void ResetData()
    {
        fakeLevelIndex = 0;
        realLevelIndex = 0;


        totalMoneyAmount = 0;

        PlayerPrefs.DeleteAll();
        SaveManager.SaveGameData(this);
    }

    [Button]
    private void SetData()
    {
        SaveManager.SaveGameData(this);
    }

    
}
