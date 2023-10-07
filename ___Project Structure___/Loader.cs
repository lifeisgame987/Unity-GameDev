using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader{
  
  public enum Scene{
    MainMenuScene,
    LoadingScene,
    GameScene
  }
  
  // static fields data don't get destroyed on scene changes, we have to manually do it
  // However, here we don't need to do that as the data is required to load destined scene
  private static Scene _targetScene;
  
  public static void Load(Scene targetScene){
    _targetScene = targetScene;
    SceneManager.LoadScene(Scene.LoadingScene.ToString());
  }
  
  public static void LoaderCallback(){
    SceneManager.LoadScene(_targetScene.ToString());
  }
}


// This object must be in Loading Scene for calling LoaderCallback
// LoadingScene -> LoaderCallbackObject
using UnityEngine;

public class LoaderCallback : MonoBehaviour{
  
  private bool _isFirstFrame = true;
  
  private void Update(){
    if(_isFirstFrame){
      _isFirstFrame = false;
      Loader.LoaderCallback();
    }
  }
}

