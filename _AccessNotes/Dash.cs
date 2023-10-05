using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class Dash : MonoBehaviour{
  
  private float _movementX;
  private bool _isFacingRight = true;
  
  [SerializeField] private float _moveSpeed;
  
  [SerializeField] private Rigidbody2D _rb;
  
  private bool _canDash = true;;
  private bool _isDashing = false;
  [SerializeField] private float _dashingPower = 24f;
  [SerializeField] private float _dashingTime = 0.2f;
  [SerializeField] private float _dashingCooldown = 1f;
  
  [SerializeField] private TrailRenderer _trail;
  
  void Start(){
    
  }
  
  void Update(){
    if(_isDashing){
      return;
    }
    
    _movementX = Input.GetAxisRaw("Horizontal");
    
    if(Input.GetKeyDown(KeyCode.LeftShift) && _canDash){
      StartCoroutine(Dash());
    }
    
    Flip();
  }
  
  void FixedUpdate(){
    if(_isDashing){
      return;
    }
    
    _rb.velocity = new Vector2(_movementX * _moveSpeed * Time.fixedDeltaTime, _rb.velocity.y);
  }
  
  private void Flip(){
    if((_isFacingRight && _movementX < 0f) || (!_isFacingRight && _movementX > 0f)){
      _isFacingRight = !_isFacingRight;
      Vector3 localScale = transform.localScale;
      localScale.x *= -1f;
      transform.localScale = localScale;
    }
  }
  
  IEnumerator Dash(){
    _canDash = false;
    _isDashing = true;
    float originalGravityScale = _rb.gravityScale;
    _rb.gravityScale = 0f;
    _rb.velocity = new Vector2(transform.localScale.x * _dashingPower, _rb.velocity.y);
    _trail.emitting = true;
    yield return new WaitForSeconds(_dashingTime);
    _trail.emitting = false;
    _rb.gravityScale = originalGravityScale;
    _isDashing = false;
    yield return new WaitForSeconds(_dashingCooldown);
    _canDash = true;
  }
}