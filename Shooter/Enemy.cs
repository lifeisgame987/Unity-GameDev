using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class Enemy : MonoBehaviour{
  
  public Tansform player;
  public float speed;
  public GameObject enemyProjectile;
  public float distance;
  private float timeBtwSpawn;
  public float startTimeBtwSpawn;
  public float health = 5f;
  public float damage = 10f;
  
  void Start(){
    timeBtwSpawn = startTimeBtwSpawn;
  }
  
  void Update(){
    if(health <= 0){
      Destroy(gameObject);
    }
    
    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    
    if(Vector2.Distance(transform.position, player.position) > distance){
      if(timeBtwSpawn <= 0f){
        Instantiate(enemyProjectile, transform.position, Quaternion.identity);
        timeBtwSpawn = startTimeBtwSpawn;
      }
      else{
        timeBtwSpawn -= Time.deltaTime;
      }
    }
  }
  
  void OnTriggerEnter2D(Collider2D other){
    if(other.CompareTag("Player")){
      other.GetComponent<Player>().health -= damage;
    }
  }
}