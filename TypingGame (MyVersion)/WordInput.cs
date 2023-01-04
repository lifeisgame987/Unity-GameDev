using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public WordManager manager;
  
  void Update(){
    foreach(char letter in Input.inputString){
      manager.CheckLetter(letter);
    }
  }
}