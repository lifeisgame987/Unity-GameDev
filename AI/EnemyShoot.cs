// Enemy script
using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class EnemyShoot : MonoBehaviour{
  
  private Transform player;
  public float speed;
  public float stopDistance;
  public float retreatDistance;
  public GameObject projectile;
  private float timeBtwShot;
  public float startTimeBtwShot;
  
  void Start(){
    player = GameObject.FindObjectWithTag("Player").transform;
    timeBtwShot = startTimeBtwShot;
  }
  
  void Update(){
    if(Vector2.Distance(transform.position, player.position) > stopDistance){
      transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
    else if(Vector2.Distance(transform.position, player.position) < stopDistance && Vector2.Distance(transform.position, player.position) > retreatDistance){
      transform.position = transform.position;
    }
    else if(Vector2.Distance(transform.position, player.position) < retreatDistance){
      transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
    }
    
    if(timeBtwShot <= 0f){
      Instantiate(projectile, transform.position, Quaternion.identity);
      timeBtwShot = startTimeBtwShot;
    }
    else{
      timeBtwShot -= Time.deltaTime;
    }
  }
}


// Projectile script
using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class Projectile : MonoBehaviour{
  
  private Transform player;
  private Vector2 target;
  public float speed;
  public GameObject particleEffect;
  
  void Start(){
    player = GameObject.FindObjectWithTag("Player").transform;
    target = player.position;
  }
  
  void Update(){
    transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime)
    
    if(Vector2.Distance(transform.position, target) < 0.1f){
      Instantiate(particleEffect, transform.position, Quaternion.identity);
      Destroy(gameObject);
    }
  }
  
  void OnTriggerEnter2D(Collider2D other){
    if(other.CompareTag("Player")){
      Destroy(gameObject);
    }
  }
}