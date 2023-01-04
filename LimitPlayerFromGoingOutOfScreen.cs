using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class LimitPlayerFromGoingOutOfScreen : MonoBehaviour{
  
  public float minX;
  public float maxX;
  public float minY;
  public float maxY;
  
  void Start(){
    
  }
  
  void Update(){
    float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
    float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
    transform.position = new Vector2(clampedX, clampedY);
  }
}