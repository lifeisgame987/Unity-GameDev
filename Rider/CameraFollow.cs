using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public Transform car;
  public Vector3 offset;
  
  void LateUpdate(){
    Vector3 newPos = car.position + offset;
    newPos.z = transform.position.z;
    transform.position = newPos;
  }
}