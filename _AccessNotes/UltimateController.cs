using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class UltimateController : MonoBehaviour{
  
  private Vector2 _moveInput;
  
  [SerializeField] private Rigidbody2D _rb;
  
  [SerializeField] private float _acceleration;
  [SerializeField] private float _maxMoveSpeed;
  [SerializeField] private float _deacceleration;
  
  [SerializeField] private float _jumpForce;
  
  [SerializeField] private float _apexBonusAccel;
  [SerializeField] private float _jumpApexThreshold;
  
  [SerializeField] private float _minFallAccel;
  [SerializeField] private float _maxFallAccel;
  [SerializeField] private float _maxfallSpeed;
  
  [SerializeField] private Transform _groundCheck;
  [SerializeField] private float _groundCheckRadius;
  [SerializeField] private LayerMask _groundLayer;
  
  private float _apexPoint;
  private bool _endedJumpEarly = true;
  
  void Start(){
    
  }
  
  void Update(){
    _moveInput.x = Input.GetAxisRaw("Horizontal");
    Jump();
  }
  
  void FixedUpdate(){
    JumpApexPoint();
    Move();
    Fall();
  }
  
  private void Move(){
    Vector2 rbVelocity = _rb.velocity;
    if(_moveInput.x != 0f){
      float acceleration = _moveInput.x * _acceleration;
      rbVelocity.x = rbVelocity.x + acceleration * Time.fixedDeltaTime;
      rbVelocity.x = Mathf.Clamp(rbVelocity.x, -_maxMoveSpeed, _maxMoveSpeed);
      
      float apexBonusAccel = _moveInput.x * _apexBonusAccel * _apexPoint;
      rbVelocity.x = rbVelocity.x + apexBonusAccel * Time.fixedDeltaTime;
    }
    else{
      rbVelocity.x = Mathf.MoveTowards(rbVelocity.x, 0, _deacceleration * Time.fixedDeltaTime);
    }
    _rb.velocity = rbVelocity;
  }
  
  private void Jump(){
    if(Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded()){
      _rb.AddForce(_jumpForce * Vector2.up, ForceMode.Impulse);
      _endedJumpEarly = false;
    }
    if(Input.GetKeyUp(KeyCode.UpArrow) && !IsGrounded() && !_endedJumpEarly && _rb.velocity.y > 0f){
      _endedJumpEarly = true;
    }
  }
  
  private void JumpApexPoint(){
    if(!IsGrounded()){
      _apexPoint = Mathf.InverseLerp(_jumpApexThreshold, 0, Mathf.Abs(_rb.velocity.y));
    }
    else{
      _apexPoint = 0f;
    }
  }
  
  private void Fall(){
    if(!IsGrounded()){
      Vector2 rbVelocity = _rb.velocity;
      float fallAccel = Mathf.Lerp(_minFallAccel, _maxFallAccel, _apexPoint);
      fallAccel = _endedJumpEarly && rbVelocity.y > 0f ? fallAccel * _fallFasterMultiplier : fallAccel;
      rbVelocity.y = rbVelocity.y - fallAccel * Time.fixedDeltaTime;
      rbVelocity.y = Mathf.Clamp(rbVelocity.y, -_maxfallSpeed, float.maxValue);
      _rb.velocity = rbVelocity;
    }
  }
  
  private bool IsGrounded(){
    return Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
  }
}