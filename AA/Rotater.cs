using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public float speed = 10f;
  
  void Start(){
    
  }
  
  void Update(){
    transform.Rotate(Vector3.forward * speed * Time.deltaTime);
  }
}