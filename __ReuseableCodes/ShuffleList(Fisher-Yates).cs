using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleList : MonoBehaviour{
  
  List<int> list = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
  
  private void Start(){
    Debug.Log("Before Shuffle => " + string.Join(", ", list));
    Shuffle(list);
    Debug.Log("After Shuffle => " + string.Join(", ", list));
  }
  
  // Fisher-Yates shuffle algorithm
  private void Shuffle<T>(List<T> inputList){
    for (int i = 0; i < inputList.Count - 1; i++){
      T temp = inputList[i];
      int rand = Random.Range(i, inputList.Count);
      inputList[i] = inputList[rand];
      inputList[rand] = temp;
    }
  }
}