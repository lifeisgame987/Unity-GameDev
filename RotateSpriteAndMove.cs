using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class RotateSpriteAndMove : MonoBehaviour{
  
  void Start(){
    
  }
  
  void Update(){
    Vector2 spritePos = transform.position;
    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Vector2 direction = mousePos - spritePos;
    transform.right = direction;
  }
}

// Make the sprite child so that the sprite can be adjusted later without changing the axis of rotation


using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class RotateSpriteAndMove : MonoBehaviour{
  
  public float rotationSpeed;
  public float moveSpeed;
  
  void Start(){
    
  }
  
  void Update(){
    Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Red2Deg;
    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    
    
    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    transform.position = Vector2.MoveTowards(transform.position, mousePos, moveSpeed * Time.deltaTime);
  }
}