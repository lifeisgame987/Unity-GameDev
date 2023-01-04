using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public float rotationSpeed = 100f;
  
  void Update(){
    transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
  }
}