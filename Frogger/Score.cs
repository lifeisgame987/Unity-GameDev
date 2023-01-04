using System.Collections;
using System.Collections.Generics;
using UnityEngine;
using UnityEngine.UI;

public class  : MonoBehaviour{
  
  public static int currentScore = 0;
  public Text scoreText;
  
  void Start(){
    scoreText.text = currentScore.ToString();
  }
}