using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public Transform target;
  
  void LateUpdate(){
    Vector3 newPos = target.position;
    newPos.z = -10f;
    transform.position = newPos;
  }
}