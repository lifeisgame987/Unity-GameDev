using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public Rigidbody2D rb;
  public float speed = 10f;
  public float minSpeed = 4f;
  public float maxSpeed = 10f;
  
  void Start(){
    speed = Random.Range(minSpeed, maxSpeed);
  }
  
  void FixedUpdate(){
    Vector2 right = new Vector2(transform.right.x, transform.right.y);
    rb.MovePosition(rb.position + right * speed * Time.fixedDeltaTime);
  }
}