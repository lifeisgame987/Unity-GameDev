using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class RandomPatrol : MonoBehaviour{
  
  public float minX;
  public float maxX;
  public float minY;
  public float maxY;
  private Vector2 target;
  public float speed;
  private float waitTime;
  public float startWaitTime;
  
  void Start(){
    waitTime = startWaitTime;
    target = RandomPos();
  }
  
  void Update(){
    if(transform.position != target){
      transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    else{
      target = RandomPos();
    }
    
    if(Vector2.Distance(transform.position, target) <= 0.2f){
      if(waitTime <= 0f){
        target = RandomPos();
        waitTime = startWaitTime;
      }
      else{
        waitTime -= Time.deltaTime;
      }
    }
    
  }
  
  Vector2 RandomPos(){
    float randX = Random.Range(minX, maxX);
    float randY = Random.Range(minY, maxY);
    return new Vector2(randX, randY);
  }
}