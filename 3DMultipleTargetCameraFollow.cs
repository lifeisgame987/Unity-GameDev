using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public List<Transform> targets;
  public Vector3 offset;
  private Vector3 velocity;
  public float smoothSpeed = 10f;
  public float maxZoom = 40f;
  public float minZoom = 10f;
  public float zoomLimiter = 50f;
  
  void LateUpdate(){
    if(targets.Count == 0){
      return;
    }
    
    Move();
    Zoom();
  }
  
  void Move(){
    Vector3 newPosition = GetCenterPosition() + offset;
    Vector3 smoothPos = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothSpeed * Time.deltaTime);
    transform.position = smoothPos;
  }
  
  void Zoom(){
    float zoomDistance = Mathf.Lerp(maxZoom, minZoom, GetZoomDistance() / zoomLimiter);
    Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoomDistance, Time.deltaTime);
    // OR
    // Camera.main.fieldOfView = Mathf.SmoothDamp(Camera.main.fieldOfView, zoomDistance, ref zoomVelocity, smoothSpeed * Time.deltaTime);
  }
  
  float GetZoomDistance(){
    var bounds = new Bounds(targets[0].position, Vector3.zero);
    for(int i=0; i<targets.Count; i++){
      bounds.Encapsulate(targets[i].position);
    }
    return bounds.size.x;
  }
  
  Vector3 GetCenterPosition(){
    if(targets.Count == 1){
      return targets[0].position;
    }
    
    var bounds = new Bounds(targets[0].position, Vector3.zero);
    for(int i=0; i<targets.Count; i++){
      bounds.Encapsulate(targets[i].position);
    }
    return bounds.center;
  }
}