using System.Collections;
using System.Collections.Generics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class  : MonoBehaviour{
  
  public Rigidbody2D rb;
  public float jumpForce = 50f;
  private string color;
  public SpriteRenderer sr;
  public Color[] colors;
  
  void Start(){
    GetRandomColor();
  }
  
  void Update(){
    if(Input.GetButtonDown("Space") || Input.GetMouseButtonDow(0)){
      // Here AddForce() is not used because it takes into account the downward force and each time it launch with extra force while velocity doesn't
      rb.velocity = Vector2.up * jumpForce;
    }
  }
  
  void GetRandomColor(){
    int index = Random.Range(0, 4);
    
    switch(index){
      case 0:
        color = "Cyan";
        sr.color = colors[index];
        break;
      case 1:
        color = "Yellow";
        sr.color = colors[index];
        break;
      case 2:
        color = "Magenta";
        sr.color = colors[index];
        break;
      case 3:
        color = "Pink";
        sr.color = colors[index];
        break;
    }
  }
  
  void OnTriggerEnter2D(Collider2D col){
    if(col.CompareTag("ColorChanger")){
      GetRandomColor();
      Destroy(col.gameObject);
      return;
    }
    
    if(col.tag != color){
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  }
}