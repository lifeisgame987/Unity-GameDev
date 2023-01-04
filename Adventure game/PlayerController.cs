using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : Monobehaviour{
  
  private Rigidbody2D rb;
  
  public float jumpForce = 10f;
  
  private bool isGrounded;
  
  // Use this function for initialisation
  void Start(){
    rb = GetComponent<Rigidbody2D>();
  }
  
  // This function is called once per frame
  void Update(){
    MoveCharacter();
  }
  
  void FixedUpdate(){
    JumpCharacter();
  }
  
  void MoveCharacter(){
    Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), transform.position.y);
    transform.position += movement * speed * Time.deltaTime;
  }
  
  void JumpCharacter(){
    if(Input.GetKeyDown("Space") && isGrounded)
      rb.AddForce(Vector2.up*jumpForce);
    }
  }
  
  void OnCollisionEnter2D(Collision2D collision){
    if(collision.CompareTag("Ground")){
      isGrounded = true;
    }
    else{
      isGrounded = false;
    }
  }
}