using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public float jumpForce = 10f;
  
  void OnCollisionEnter2D(Collision2D collision){
    if(collision.relativeVelocity.y <= 0f){
      Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
      if(rb != null){
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
      }
    }
  }
}