using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class TowerDefence : MonoBehaviour{
  
  public Transform[] waypoints;
  public int waypointIndex;
  public float speed;
  
  void Start(){
    
  }
  
  void Update(){
    transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].position, speed * Time.deltaTime);
    
    Vector2 dir = waypoints[waypointIndex].position - transform.position;
    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    
    if(Vector2.Distance(transform.position, waypoints[waypointIndex].position) <= 0.2f){
      if(waypointIndex < waypoints.Length - 1){
        waypointIndex++;
      }
      else{
        transform.position = waypoints[waypointIndex].position;
      }
    }
  }
}



using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class TowerDefence : MonoBehaviour{
  
  public Transform[] waypoints;
  private int waypointIndex = 0;
  public float speed;
  private bool forward = true;
  
  void Start(){
    
  }
  
  void Update(){
    transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].position, speed * Time.deltaTime);
    
    Vector2 dir = waypoints[waypointIndex].position - transform.position;
    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    
    if(Vector2.Distance(transform.position, waypoints[waypointIndex].position) <= 0.1f){
      
      if(waypointIndex < waypoints.Length-1 && forward){
        waypointIndex++;
      }
      else if(waypointIndex > 0 && !forward){
        waypointIndex--;
      }
      
      if(waypointIndex == waypoints.Length-1){
        forward = false;
      }
      else if(waypointIndex == 0){
        forward = true;
      }
    }
  }
}