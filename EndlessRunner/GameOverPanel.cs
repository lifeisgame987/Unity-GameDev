using System.Collections;
using System.Collections.Generics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour{
  
  void Start(){
    
  }
  
  void Update(){
    if(Input.GetKeyDown(KeyCode.R)){
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  }
}