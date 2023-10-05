using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class DoubleJump : MonoBehaviour{
  
  [SerializeField] private float _jumpPower;
  [SerializeField] private int _noOfJumps = 2;
  private int _jumpCounter;
  
  [SerializeField] private Transform _groundCheck;
  [SerializeField] private float _groundCheckRadius;
  [SerializeField] private LayerMask _groundLayer;
  
  [SerializeField] private Rigidbody2D _rb;
  
  void Start(){
    
  }
  
  void Update(){
    if(Input.GetButtonDown("Jump")){
      if(IsGrounded()){
        _jumpCounter = _noOfJumps;
      }
      
      if(_jumpCounter > 0 && _jumpCounter <= _noOfJumps){
        _rb.velocity = new Vector2(_rb.velocity.x, _jumpPower);
        _jumpCounter -= 1;
      }
    }
  }
  
  private bool IsGrounded(){
    return Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
  }
}