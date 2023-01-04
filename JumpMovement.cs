using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class JumpMovement : MonoBehaviour{
  
  public float jumpForce;
  private Rigidbody2D rb;
  
  private bool isGrounded = true;
  private bool upButtonPressed = false;
  
  void Start(){
    rb = GetComponent<Rigidbody2D>();
  }
  
  void Update(){
    upButtonPressed = Input.GetKeyDown(KeyCode.UpArrow);
  }
  
  void FixedUpdate(){
    if(upButtonPressed && isGrounded){
      rb.AddForce(new Vector2(transform.position.x, jumpforce));
    }
  }
  
  void OnCollisionEnter2D(Collision2D collision){
    if(collision.tag == "Ground"){
      isGrounded = true;
    }
    else{
      isGrounded = false;
    }
  }
}


// Keep the groundCheck GameObject child of Player
using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class JumpMovement : MonoBehaviour{
  
  public float jumpForce;
  public float groundCheckCircleRadius;
  public Transform groundCheckCircle;
  public LayerMask whatIsGround;
  private Rigidbody2D rb;
  
  private bool isGrounded = true;
  private bool buttonPressed = false;
  
  void Start(){
    rb = GetComponent<Rigidbody2D>();
  }
  
  void Update(){
    buttonPressed = Input.GetKeyDown(KeyCode.UpArrow);
  }
  
  void FixedUpdate(){
    isGrounded = Physics2D.OverlapCircle(groundCheckCircle.position, groundCheckCircleRadius, whatIsGround);
    
    if(isGrounded && buttonPressed){
      rb.velocity = Vector2.up * jumpForce;
    }
  }
}


// Keep the groundCheck GameObject child of Player
// Double jump/Triple jump
using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class JumpMovement : MonoBehaviour{
  
  public float jumpForce;
  public float groundCheckCircleRadius;
  public Transform groundCheckCircle;
  public LayerMask whatIsGround;
  private Rigidbody2D rb;
  
  private bool isGrounded = true;
  private bool buttonPressed = false;
  
  private int extraJumps = 0;
  public int extraJumpsValue;
  
  void Start(){
    rb = GetComponent<Rigidbody2D>();
  }
  
  void Update(){
    buttonPressed = Input.GetKeyDown(KeyCode.UpArrow);
    
    if(isGrounded){
      extraJumps = extraJumpsValue;
    }
  }
  
  void FixedUpdate(){
    isGrounded = Physics2D.OverlapCircle(groundCheckCircle.position, groundCheckCircleRadius, whatIsGround);
    
    if(buttonPressed && extraJumps>0){
      rb.velocity = Vector2.up * jumpForce;
      extraJumps--;
    }
  }
}