using System.Collections;
using System.Collections.Generics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class  : MonoBehaviour{
  
  void OnTriggerEnter2D(Collider2D col){
    if(col.CompareTag("Car")){
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  }
}