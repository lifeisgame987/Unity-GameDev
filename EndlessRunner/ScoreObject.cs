using System.Collections;
using System.Collections.Generics;
using UnityEngine;
using UnityEngine.UI;

public class ScoreObject : MonoBehaviour{
  
  private int score = 0;
  public Text scoreText;
  
  void Start(){
    
  }
  
  void Update(){
    scoreText.text = score.ToString();
  }
  
  private void OnTriggerEnter2D(Collision2D other){
    if(other.CompareTag("Obstacle")){
      score++;
    }
  }
}