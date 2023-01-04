using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  void OnTriggerEnter2D(Collider2D col){
    Chain.IsFired = false;
    if(col.CompareTag("Ball")){
      col.GetComponent<Ball>().Split();
    }
  }
}