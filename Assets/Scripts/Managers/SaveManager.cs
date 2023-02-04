using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager
{
	public static void LoadGameData<T>(T gameData)
	{
		if (!PlayerPrefs.HasKey(gameData.ToString()))
		{
			SaveGameData(gameData);
			return;
		}

		string dataString = PlayerPrefs.GetString(gameData.ToString());
		JsonUtility.FromJsonOverwrite(dataString, gameData);
	}
	public static void SaveGameData<T>(T gameData)
	{
		string dataString = JsonUtility.ToJson(gameData);
		PlayerPrefs.SetString(gameData.ToString(), dataString);
	}

}
