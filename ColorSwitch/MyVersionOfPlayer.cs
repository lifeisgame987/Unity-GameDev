using System.Collections;
using System.Collections.Generics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class  : MonoBehaviour{
  
  private Rigidbody2D rb;
  public float launchForce;
  private string color;
  private int index;
  private SpriteRenderer sr;
  public Color[] colors;
  
  void Start(){
    rb = GetComponent<Rigidbody2D>();
    sr = GetComponent<SpriteRenderer>();
    index = Random.Range(0, 4);
    color = GetRandomColorName(index);
    sr.color = colors[index];
  }
  
  void Update(){
    if(Input.GetButtonDown("Space") || Input.GetMouseButtonDown(0)){
      rb.velocity = Vector2.up * launchForce;
    }
  }
  
  string GetRandomColorName(int index){
    switch(index){
      case 0:
        return "Cyan";
      case 1:
        return "Yellow";
      case 2:
        return "Magenta";
      default:
        return "Pink";
    }
  }
  
  void OnTriggerEnter2D(Collider2D col){
    if(col.tag == "ChangeColor"){
      // Everytime it collides it will check the previous color and change itself to another color, if the new color is the previous color it will choose another color and check again and change itself
      int newIndex = Random.Range(0, 4);
      while(true){
        if(index != newIndex){
          color = GetRandomColorName(newIndex);
          sr.color = colors[newIndex];
          index = newIndex;
          break;
        }
        else{
          newIndex = Random.Range(0, 4);
        }
      }
      Destroy(col.gameObject);
      return;
    }
    
    if(col.tag != color){
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  }
}