using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public Transform target;
  public Vector3 offset;
  public float smoothSpeed = 10f;
  
  void LateUpdate(){
    Vector3 newPosition = target.position + offset;
    transform.position = Vector3.Lerp(transform.position, newPosition, smoothSpeed * Time.deltaTime);
  }
}