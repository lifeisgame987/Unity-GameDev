using System.Collections;
using System.Collections.Generics;
using UnityEngine;
using UnityEngine.UI;

public class  : MonoBehaviour{
  
  public Text scoreText;
  public static int score;
  
  void Start(){
    score = 0;
  }
  
  void Update(){
    scoreText.text = score.ToString();
  }
}