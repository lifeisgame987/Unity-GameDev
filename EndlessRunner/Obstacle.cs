using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class Obstacle : MonoBehaviour{
  
  public float speed;
  
  void Start(){
    
  }
  
  void Update(){
    transform.Translate(transform.left * speed * time.deltaTime);
  }
}