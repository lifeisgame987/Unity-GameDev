using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public float speed = 50f;
  
  void Update(){
    transform.Rotate(Vector3.forward * -speed * Time.deltaTime);
  }
}