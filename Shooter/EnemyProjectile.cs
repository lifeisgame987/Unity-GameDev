using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour{
  
  private Vector2 target;
  public Transform player;
  public float projectileSpeed;
  public float health = 1f;
  public float damage = 5f
  
  void Start(){
    target = player.position;
  }
  
  void Update(){
    if(health <= 0){
      Destroy(gameObject);
    }
    
    transform.position = Vector2.MoveTowards(transform.position, target, projectileSpeed * Time.deltaTime);
    if(Vector2.Distance(transform.position, target) < 0.2f){
      Destroy(gameObject);
    }
  }
  
  void OnTriggerEnter2D(Collider2D other){
    if(other.CompareTag("Player")){
      other.GetComponent<Player>().health -= damage;
    }
  }
}