using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public Rigidbody2D rb;
  private bool isMoving = false;
  private bool isGrounded = false;
  
  public float speed = 2000f
  public float rotationSpeed = 700f;
  
  void Update(){
    if(Input.GetButtonDown("Fire1")){
      isMoving = true;
    }
    if(Input.GetButtonUp("Fire1")){
      isMoving = false;
    }
  }
  
  void FixedUpdate(){
    if(isMoving){
      if(isGrounded){
        rb.AddForce(transform.right * speed * Time.fixedDeltaTime);
      }
      else{
        rb.AddTorque(rotationSpeed * Time.fixedDeltaTime);
      }
    }
  }
  
  void OnCollisionEnter2D(){
    isGrounded = true;
  }
  
  void OnCollisionExit2D(){
    isGrounded = false;
  }
}