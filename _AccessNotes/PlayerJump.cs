using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class PlayerJump : MonoBehaviour{
  
  [SerializeField] private float _jumpPower;
  [SerializeField] private Transform _groundCheck;
  [SerializeField] private float _groundCheckRadius;
  [SerializeField] private LayerMask _groundLayer;
  [SerializeField] private Rigidbody2D _rb;
  
  void Start(){
    
  }
  
  void Update(){
    if(Input.GetButtonDown("Jump") && IsGrounded()){
      _rb.velocity = new Vector2(_rb.velocity.x, _jumpPower);
    }
    
    if(Input.GetButtonUp("Jump") && _rb.velocity.y > 0f){
      _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);
    }
  }
  
  private bool IsGrounded(){
    return Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);
  }
}