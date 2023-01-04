using System.Collections;
using System.Collections.Generics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
  
  private static GameManager instance;
  
  public float slowness = 10f;
  
  void Awake(){
    if(instance == null){
      instance = this;
      DontDestroyOnLoad(gameObject);
    }
    else{
      Destroy(gameObject);
    }
  }
  
  public void EndGame(){
    StartCoroutine(RestartLevel());
  }
  
  IEnumerator RestartLevel(){
    Time.timeScale = 1f / slowness;
    Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;
    
    yield return new WaitForSeconds(1f / slowness);
    
    Time.timeScale = 1f;
    Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;
    
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }
}