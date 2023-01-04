using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class MoveTowardsRandomPos : MonoBehaviour{
  
  public float minX;
  public float maxX;
  public float minY;
  public float maxY;
  public float speed;
  private Vector2 targetPosition;
  
  void Start(){
    targetPosition = GetRandomPosition();
  }
  
  void Update(){
    if((Vector2)transform.position != targetPosition){
      transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
    else{
      targetPosition = GetRandomPosition();
    }
  }
  
  Vector2 GetRandomPosition(){
    float randX = Random.Range(minX, maxX);
    float randY = Random.Range(minY, maxY);
    return new Vector2(randX, randY);
  }
}