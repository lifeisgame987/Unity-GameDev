using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class PlayerMovement2d : MonoBehaviour{
  
  private float _movementX;
  private bool _isFacingRight = true;
  
  [SerializeField] private float _moveSpeed;
  [SerializeField] private Rigidbody2D _rb;
  
  void Start(){
    
  }
  
  void Update(){
    _movementX = Input.GetAxisRaw("Horizontal");
    
    Flip(transform, _movementX, _isFacingRight);
  }
  
  void FixedUpdate(){
    Move(_rb, _movementX, _moveSpeed, Time.fixedDeltaTime);
  }
  
  private void Move(Rigidbody2D rb, float input, float speed, float time){
    rb.velocity = new Vector2(input * speed * time, rb.velocity.y);
  }
  
  private void Flip(Transform tf, float input, bool isFacingRight){
    if((isFacingRight && input < 0f) || (!isFacingRight && input > 0f)){
      Vector3 localScale = tf.localScale;
      localScale.x *= -1f;
      tf.localScale = localScale;
      _isFacingRight = !isFacingRight;
    }
  }
}