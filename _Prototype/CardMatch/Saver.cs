using UnityEngine;

public static class Saver
{
	private const string IS_LEVEL_COMPLETED = "IsLevelCompleted";
	private const string NUMBER_OF_STARS = "NumberOfStars";

	public static void SaveLevelData(string levelName, LevelData data)
	{
		PlayerPrefs.SetInt(levelName + IS_LEVEL_COMPLETED, GetIntFromBool(data.IsLevelCompleted));
		PlayerPrefs.SetInt(levelName + NUMBER_OF_STARS, data.NumberOfStars);
		PlayerPrefs.Save();
	}

	public static LevelData LoadLevelData(string levelName)
	{
		LevelData data = new LevelData();
		data.IsLevelCompleted = GetBoolFromInt(PlayerPrefs.GetInt(levelName + IS_LEVEL_COMPLETED, 0));
		data.NumberOfStars = PlayerPrefs.GetInt(levelName + NUMBER_OF_STARS, 0);
		return data;
	}

	public static void DeleteAllSavedData()
	{
		PlayerPrefs.DeleteAll();
	}

	private static int GetIntFromBool(bool value)
	{
		return value ? 1 : 0;
	}

	private static bool GetBoolFromInt(int value)
	{
		return value == 1;
	}
}

public class LevelData
{
	public bool IsLevelCompleted;
	public int NumberOfStars;
}
