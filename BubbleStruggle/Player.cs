using System.Collections;
using System.Collections.Generics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class  : MonoBehaviour{
  
  private Rigidbody2D rb;
  private float movement = 0f;
  public float speed = 10f;
  
  void Start(){
    rb = GetComponent<Rigidbody2D>();
  }
  
  void Update(){
    movement = Input.GetAxis("Horizontal") * speed;
  }
  
  void FixedUpdate(){
    rb.MovePosition(rb.position + new Vector2(movement * Time.fixedDeltaTime));
  }
  
  void OnCollisionEnter2D(Collision2D col){
    if(col.collider.CompareTag("Ball")){
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  }
}