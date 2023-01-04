using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  private static string[] words = {};
  
  public static string GetRandomWord(){
    int index = Random.Range(0, words.Length);
    return words[index];
  }
}