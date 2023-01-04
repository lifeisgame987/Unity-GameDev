using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public float speed;
  public float amplitude;
  public float minRot = -45f;
  public float maxRot = 45f;
  
  void Update(){
    float rotation = Mathf.Cos(Time.time * speed) * amplitude;
    transform.localEulerAngles = Vector3.forward * rotation * Time.deltaTime;
    transform.localEulerAngles.z = Mathf.Clamp(transform.localEulerAngles.z, minRot, maxRot);
  }
}