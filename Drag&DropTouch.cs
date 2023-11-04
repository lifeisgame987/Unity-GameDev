using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class Drag&DropTouch : MonoBehaviour{
  
  private bool moveAllowed = false;
  private Collider2D collider;
  
  void Start(){
    collider = GetComponent<Collider2D>();
  }
  
  void Update(){
    if(Input.touchCount > 0){
      Touch touch = Input.GetTouch(0);
      Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
      
      if(touch.phase == TouchPhase.Began){
        Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition)
        if(touchedCollider == collider){
          moveAllowed = true;
        }
      }
      
      if(touch.phase == TouchPhase.Moved){
        if(moveAllowed){
          transform.position = new Vector2(touchPosition.x, touchPosition.y)
        }
      }
      
      if(touch.phase == TouchPhase.Ended){
        moveAllowed = false;
      }
    }
  }
}