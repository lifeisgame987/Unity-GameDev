using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  private Rigidbody2D rb;
  private float x = 0f;
  public float speed = 10f;
  
  void Start(){
    rb = GetComponent<Rigidbody2D>();
  }
  
  void Update(){
    x = Input.GetAxis("Horizontal") * speed;
  }
  
  void FixedUpdate(){
    rb.MovePosition(rb.position + Vector2.right * x * Time.fixedDeltaTime);
  }
  
  void OnCollisionEnter2D(){
    GameManager.instance.EndGame();
  }
}