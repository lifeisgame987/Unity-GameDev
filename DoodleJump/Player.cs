using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  private Rigidbody2D rb;
  public float movementSpeed = 3f;
  private float movement = 0f;
  
  void Start(){
    rb = GetComponent<Rigidbody2D>();
  }
  
  void Update(){
    movement = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime;
  }
  
  void FixedUpdate(){
    rb.velocity = new Vector2(movement, rb.velocity.y);
  }
}