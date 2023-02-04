using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class ScriptableManager : MonoBehaviour
{
    [SerializeField] GameData gameData;
    [SerializeField] PlayerMovementSettings PlayerMovementSettings;


    //-------------------------------------------------------------------
    void Awake()
    {
        SaveManager.LoadGameData(gameData);

        Scriptable.GameData = GetGameData;
        Scriptable.PlayerSettings = GetPlayerMovementSettings;
    }


    //-------------------------------------------------------------------
    GameData GetGameData() => gameData;


    //-------------------------------------------------------------------
    PlayerMovementSettings GetPlayerMovementSettings() => PlayerMovementSettings;

}



public static class Scriptable
{
    public static Func<GameData> GameData;
    public static Func<PlayerMovementSettings> PlayerSettings;
}