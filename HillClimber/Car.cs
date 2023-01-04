using System.Collections;
using System.Collections.Generics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class  : MonoBehaviour{
  
  public WheelJoint2D backWheel;
  public WheelJoint2D frontWheel;
  private float carMovement = 0f;
  public float speed = 20f;
  private float rotationMove = 0f;
  public float rotationSpeed = 20f;
  public Rigidbody2D rb;
  
  void Update(){
    carMovement = -Input.GetAxisRaw("Vertical") * speed;
    rotationMove = Input.GetAxisRaw("Horizontal") * rotationSpeed;
  }
  
  void FixedUpdate(){
    if(movement == 0f){
      backWheel.useMotor = false;
      frontWheel.useMotor = false;
    }
    else{
      backWheel.useMotor = true;
      frontWheel.useMotor = true;
      
      // (motorSpeed) can't be accessed as it is wrapped in (struct) so we have to create an instance of the (struct) and add necessary data to the (struct) parameters and assign it to the required field
      JointMotor2D motor = new JointMotor2D{
        motorSpeed = carMovement * Time.fixedDeltaTime, 
        maxMotorTorque = backWheel.motor.maxMotorTorque
      }
      
      backWheel.motor = motor;
      frontWheel.motor = motor;
    }
    
    rb.AddTorque(-rotationMove * Time.fixedDeltaTime);
  }
  
  void OnTriggerEnter2D(Collider2D col){
    if(col.CompareTag("Collidable")){
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  }
}