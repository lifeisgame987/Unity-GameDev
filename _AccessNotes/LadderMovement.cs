using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class LadderMovement : MonoBehaviour{
  
  private bool _isLadder = false;
  private bool _isClimbing = false;
  private Vector2 _movementY;
  private float _orginalGravityScale;
  
  [SerializeField] private float _speed;
  [SerializeField] private Rigidbody2D _rb;
  
  void Start(){
    _orginalGravityScale = _rb.gravityScale;
  }
  
  void Update(){
    _movementY = Input.GetAxisRaw("Vertical");
    
    if(_isLadder && Mathf.Abs(_movementY) > 0f){
      _isClimbing = true;
    }
  }
  
  void FixedUpdate(){
    if(_isClimbing){
      _rb.gravityScale = 0f;
      _rb.velocity = new Vector2(_rb.velocity.x, _movementY * _speed);
    }
    else{
      _rb.gravityScale = _orginalGravityScale;
    }
  }
  
  void OnTriggerEnter2D(Collider2D col){
    if(col.CompareTag("Ladder")){
      _isLadder = true;
    }
  }
  
  void OnTriggerExit2D(Collider2D col){
    if(col.CompareTag("Ladder")){
      _isLadder = false;
      _isClimbing = false;
    }
  }
}