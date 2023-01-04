using System.Collections;
using System.Collections.Generics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class  : MonoBehaviour{
  
  private Rigidbody2D rb;
  public float moveSpeed = 100f;
  private bool stopMove = false;
  public GameObject rotater;
  private Pin pin;
  public Animater anim;
  
  void Start(){
    rb = GetComponent<Rigidbody2D>();
    pin = GetComponent<Pin>();
  }
  
  void Update(){
    if(!stopMove){
      rb.MovePosition(rb.position + Vector2.up * moveSpeed * Time.deltaTime);
    }
  }
  
  void OnTriggerEnter2D(Collider2D collider){
    if(collider.CompareTag("Rotater")){
      transform.SetParent(collider.transform);
      
      rotater.GetComponent<Rotater>().speed *= -1;
      
      Score.score++;
      
      stopMove = true;
    }
    else if(collider.CompareTag("Pin")){
      anim.SetTrigger("GameOver");
      pin.enabled = false;
      rotater.GetComponent<Rotater>().enabled = false;
      Invoke("ReloadScene", 2f);
    }
  }
  
  void ReloadScene(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }
}