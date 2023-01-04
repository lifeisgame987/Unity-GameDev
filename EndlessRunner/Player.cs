using System.Collections;
using System.Collections.Generics;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour{
  
  public float Yincrement = 2f;
  private Vector2 Ymovement;
  public float speed = 10f;
  public float health = 5f;
  public GameObject gameOverPanel;
  public GameObject damageParticleEffect;
  public GameObject moveParticleEffect;
  public Text healthText;
  
  void Start(){
    Ymovement = new Vector2(transform.position.x, transform.position.y);
  }
  
  void Update(){
    
    healthText.text = health.ToString();
    
    if(health<=0){
      Destroy(gameObject);
      gameOverPanel.SetEnabled(true);
    }
    
    if(Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < 4){
      Instantiate(moveParticleEffect, transform.position, Quaternion.identity);
      Ymovement = new Vector2(transform.position.x, transform.position.y + Yincrement);
    }
    else if(Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > -4){
      Instantiate(moveParticleEffect, transform.position, Quaternion.identity);
      Ymovement = new Vector2(transform.position.x, transform.position.y - Yincrement);
    }
    transform.position = Vector2.MoveTowards(transform.position, Ymovement, speed * Time.deltaTime);
  }
  
  private void OnTriggerEnter2D(Collision2D other){
    if(other.CompareTag("Obstacle")){
      Instantiate(damageParticleEffect, transform.position, Quaternion.identity);
      health--;
    }
  }
}