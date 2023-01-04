using System.Collections;
using System.Collections.Generics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class  : MonoBehaviour{
  
  void OnTriggerEnter2D(){
    Score.currentScore += 100;
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }
}