using UnityEngine;
using UnityEngine.SceneManagement;
using Sirenix.OdinInspector;
using UnityEngine.Serialization;

public class LevelManager : MonoBehaviour
{
	[SerializeField] private GameData gameData;
	private bool _isLevelChanged;
	private void OnEnable()
	{
		EventManager.RestartLevel += ResetLevel;
		EventManager.OpenNextLevel += LoadNextLevel;
	}
	private void OnDisable()
	{
		EventManager.RestartLevel -= ResetLevel;
		EventManager.OpenNextLevel -= LoadNextLevel;
	}
	private void Start()
	{
		if (PlayerPrefs.HasKey("FirstLaunch") == true)
		{
			//do nothing game already launched before
		}
		else if (PlayerPrefs.HasKey("FirstLaunch") == false)
		{
			PlayerPrefs.DeleteAll();
			
			PlayerPrefs.SetInt("FirstLaunch", 1);

			gameData.fakeLevelIndex = 0;
			gameData.realLevelIndex = 0;


			gameData.totalMoneyAmount = 0;
			
			SaveManager.SaveGameData(gameData);
		}
		
		SaveManager.LoadGameData(gameData);

		if (SceneManager.GetActiveScene().buildIndex == 0)
			LoadLevel();
	}
	private void LoadLevel()
	{
		

		if (gameData.fakeLevelIndex % gameData.levelLoopValue == 0)
			gameData.realLevelIndex = 0;
		else 
			gameData.realLevelIndex = gameData.fakeLevelIndex % gameData.levelLoopValue;

		SaveManager.SaveGameData(gameData);
		SceneManager.LoadScene(1 + gameData.realLevelIndex);
	}
	private void LoadNextLevel()
	{
		if (_isLevelChanged == true)
			return;
		_isLevelChanged = true;
		
		SceneManager.LoadScene(1 + gameData.realLevelIndex);
	}
	private void ResetLevel()
	{
		SceneManager.LoadScene(1 + gameData.realLevelIndex);
	}
}
