using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  private WordManager wordManager;
  
  void Start(){
    wordManager = GetComponent<WordManager>();
  }
  
  void Update(){
    foreach(char letter in Input.inputString){
      wordManager.TypeLetter(letter);
    }
  }
}