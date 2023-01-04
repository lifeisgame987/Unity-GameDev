using System.Collections;
using System.Collections.Generics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
  
  private static GameManager instance;
  private bool isGameOver = false;
  
  void Awake(){
    if(instance == null){
      instance = this;
      DontDestroyOnLoad(gameObject);
    }
    else{
      Destroy(gameObject);
    }
  }
  
  public void Reload(){
    if(isGameOver){
      return;
    }
    isGameOver = true;
    StartCoroutine(RestartScene());
  }
  
  IEnumerator RestartScene(){
    Debug.Log("Game Over!!");
    yield return new WaitForSeconds(1f);
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }
}