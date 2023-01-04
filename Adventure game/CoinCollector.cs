using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CoinCollector : Monobehaviour{
  
  public float coinValue = 5f;
  
  void Start(){
    
  }
  
  void Update(){
    
  }
  
  void OnTriggerEnter2D(Collision2D collision){
    if(collision.CompareTag("Player")){
      float coinScore = 0;
      coinScore += coinValue;
      score.text = "Score: " + coinScore;
      Destroy(gameObject);
    }
  }
}