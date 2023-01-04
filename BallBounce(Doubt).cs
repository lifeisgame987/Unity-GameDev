using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class BallBounce : MonoBehaviour{
  
  private bool moveAllowed = false;
  private Collider2D collider;
  private Rigidbody2D rb;
  private LineRenderer line;
  public float lineMaxLength;
  public float force;
  
  void Start(){
    collider = GetComponent<Collider2D>();
    rb = GetComponent<Rigidbody2D>();
    line = GetComponent<LineRenderer>();
    line.positionCount = 2;
    line.SetPosition(0, transform.position);
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
          Vector2 dirOfObjectToTouch = touchPosition - transform.position;
          Vector2 clampedDirTouchPos = Vector2.ClampMagnitude(dirOfObjectToTouch, lineMaxLength);
          Vector2 lineExactEndPosition = transform.position + clampedDirTouchPos;
          line.SetPosition(1, lineExactEndPosition);
        }
      }
      
      if(touch.phase == TouchPhase.Ended){
        Vector2 clampedDirTouchPos = Vector2.ClampMagnitude(touchPosition - transform.position, lineMaxLength);
        Vector2 ballForce = clampedDirTouchPos * force * Time.deltaTime * -1;
        rb.velocity = ballForce;
        line.SetPosition(1, transform.position);
        moveAllowed = false;
      }
    }
  }
}