using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameData gameData;
    private bool _isProgress;
    private bool isGameCompleted;
    private bool isGameStarted;
    private Scene thisScene;



    //---------------------------------------------------------------------------------
    private void OnEnable()
    {
        EventManager.StartLevel += LevelStarted;
        EventManager.SetWin += SetWinGame;
        EventManager.SetLose += SetLoseGame;
        EventManager.IsGameCompleted = () => isGameCompleted;
        EventManager.IsGameStarted = () => isGameStarted;
    }
    private void OnDisable()
    {
        EventManager.StartLevel -= LevelStarted;
        EventManager.SetWin -= SetWinGame;
        EventManager.SetLose -= SetLoseGame;
    }


    //---------------------------------------------------------------------------------
   


    //---------------------------------------------------------------------------------
    private void LevelStarted()
    {
        isGameStarted = true;
        EventManager.OnGameStarted?.Invoke();

        //ElephantSDK.Elephant.LevelStarted(gameData.fakeLevelIndex + 1);
        thisScene = SceneManager.GetActiveScene();
    }


    //---------------------------------------------------------------------------------
    private void SetWinGame()
    {
        if (_isProgress == true)
            return;

        isGameCompleted = true;
        EventManager.OnGameCompleted?.Invoke();


        gameData.fakeLevelIndex++;

        if (gameData.fakeLevelIndex % gameData.levelLoopValue == 0)
            gameData.realLevelIndex = 0;
        else
            gameData.realLevelIndex = gameData.fakeLevelIndex % gameData.levelLoopValue;

        _isProgress = true;

        SaveManager.SaveGameData(gameData);
    }


    //---------------------------------------------------------------------------------
    private void SetLoseGame()
    {
        isGameCompleted = true;
        EventManager.OnGameCompleted?.Invoke();
    }
}