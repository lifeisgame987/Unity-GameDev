using UnityEngine;

public class MainMenuTimeScaleResetter : MonoBehaviour{
  
  private void Awake(){
    // As the game play uses pause/resume system, scene changes will
    // make the game potentially stay in pause, so we have to manually
    // resume it in the first Scene (MainMenuScene)
    Time.timeScale = 1f;
  }
}
