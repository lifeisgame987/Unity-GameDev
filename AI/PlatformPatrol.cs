using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class PlatformPatrol : MonoBehaviour{
  
  public float speed;
  public Transform groundDetection;
  public float distance;
  private bool movingRight = true;
  
  void Start(){
    
  }
  
  void Update(){
    transform.Translate(Vector2.right * speed * Time.deltaTime);
    
    RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
    if(groundInfo.collider == null){
      if(movingRight){
        transform.eulerAngles = new Vector3(0, -180, 0);
        movingRight = false;
      }
      else{
        transform.eulerAngles = new Vector3(0, 0, 0);
        movingRight = true;
      }
    }
  }
}