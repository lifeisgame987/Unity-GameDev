using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class WallSlideAndJump : MonoBehaviour{
  
  private Vector2 _moveInput;
  
  [SerializeField] private Rigidbody2D _rb;
  [SerializeField] private float _maxSlideSpeed;
  [SerializeField] private Transform _wallCheck;
  [SerializeField] private float _wallCheckRadius;
  [SerializeField] private LayerMask _wallLayer;
  
  [SerializeField] private Transform _groundCheck;
  [SerializeField] private float _groundCheckRadius;
  [SerializeField] private LayerMask _groundLayer;
  
  private bool _isSliding = false;
  
  void Start(){
    
  }
  
  void Update(){
    _moveInput.x = Input.GetAxisRaw("Horizontal");
    
    if(IsWalled() && !IsGrounded() && _moveInput.x != 0f){
      _isSliding = true;
    }
    else{
      _isSliding = false;
    }
    
    if(_isSliding){
      WallSlide();
    }
    
    if(Input.GetKeyDown(KeyCode.UpArrow) && _isSliding){
      WallJump();
    }
  }
  
  private void WallSlide(){
    _rb.velocity = new Vector2(_rb.velocity.x, Mathf.Clamp(_rb.velocity.y, -_maxSlideSpeed, float.maxValue));
  }
  
  private bool IsWalled(){
    return Physics2D.OverlapCircle(_wallCheck.position, _wallCheckRadius, _wallLayer);
  }
  
  private bool IsGrounded(){
    return Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
  }
  
  private void WallJump(){
    Vector2 wallJumpForce;
    wallJumpForce.x = _moveInput.x * _wallJumpForceX;
    wallJumpForce.y = _wallJumpForceY;
    
    _rb.AddForce(wallJumpForce * Vector2.one, ForceMode.Impulse);
  }
}