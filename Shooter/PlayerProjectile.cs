using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour{
  
  public float radius;
  public float speed;
  private Vector2 mousePos;
  public float areaOfEffect;
  public LayerMask whatIsEnemyProjectile;
  public LayerMask whatIsEnemy;
  public float damage = 1f;
  
  void Start(){
    mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Vector2 dir = mousePos - transform.position;
    mousePos = transform.position + Vector2.ClampMagnitude(dir, radius);
  }
  
  void Update(){
    transform.position = Vector2.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
    
    if(Vector2.Distance(transform.position, mousePos) <= 0.2f){
      Destroy(gameObject);
    }
  }
  
  void OnTriggerEnter2D(Collider2D other){
    if(other.CompareTag("EnemyProjectile")){
      Collider2D objToDamage = Physics2D.OverlapCircle(transform.position, areaOfEffect, whatIsEnemyProjectile);
      objToDamage.GetComponent<EnemyProjectile>().health -= damage;
    }
    if(other.CompareTag("Enemy")){
      Collider2D objToDamage = Physics2D.OverlapCircle(transform.position, areaOfEffect, whatIsEnemy);
      objToDamage.GetComponent<Enemy>().health -= damage;
    }
  }
}