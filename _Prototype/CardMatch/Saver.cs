public static class Saver{
  
  private const string IS_LEVEL_COMPLETED = "IsLevelCompleted";
  private const string NUMBER_OF_STARS = "NumberOfStars";
  
  private const string IS_CARD_UI_OPENED = "IsCardUIOpened";
  
  public static void SaveLevelData(string levelName, LevelData data){
    PlayerPrefs.SetInt(levelName + IS_LEVEL_COMPLETED, GetInt(data.IsLevelCompleted));
    PlayerPrefs.SetInt(levelName + NUMBER_OF_STARS, data.NumberOfStars);
    PlayerPrefs.Save();
  }
  
  public static LevelData LoadLevelData(string levelName){
    LevelData data = new LevelData();
    data.IsLevelCompleted = GetBool(PlayerPrefs.GetInt(levelName + IS_LEVEL_COMPLETED, 0));
    data.NumberOfStars = PlayerPrefs.GetInt(levelName + NUMBER_OF_STARS, 0);
    return data;
  }
  
  public static void DeleteSpecificLevelData(string levelName){
    PlayerPrefs.DeleteKey(levelName + IS_LEVEL_COMPLETED);
    PlayerPrefs.DeleteKey(levelName + NUMBER_OF_STARS);
  }
  
  public static void SaveCardUIOpen(string levelName, bool isCardUIOpened){
    PlayerPrefs.SetInt(levelName + IS_CARD_UI_OPENED, GetInt(isCardUIOpened));
    PlayerPrefs.Save();
  }
  
  public static bool LoadCardUIOpen(string levelName){
    return GetBool(PlayerPrefs.GetInt(levelName + IS_CARD_UI_OPENED));
  }
  
  public static void DeleteSpecificCardUIOpenData(string levelName){
    PlayerPrefs.DeleteKey(levelName + IS_CARD_UI_OPENED);
  }
  
  public static void DeleteAllSavedData(){
    PlayerPrefs.DeleteAll();
  }
  
  private static bool GetBool(int value){
    return value == 1;
  }
  
  private static int GetInt(bool value){
    return value ? 1 : 0;
  }
}

public class LevelData{
  public bool IsLevelCompleted;
  public int NumberOfStars;
}