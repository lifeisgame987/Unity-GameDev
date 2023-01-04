using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class Background : MonoBehaviour{
  
  public float speed;
  public float endX;
  public float startX;
  
  void Start(){
    
  }
  
  void Update(){
    transform.Translate(Vector2.left * speed * time.deltaTime);
    if(transform.position.x < endX){
      Vector2 pos = new Vector2(startX, transform.position.y);
      transform.position = pos;
    }
  }
}

// Attached to 2 background sprite