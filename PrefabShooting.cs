// PlayerShoot script
using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public Transform firePoint;
  public GameObject bulletPrefab;
  
  void Update(){
    if(Input.GetButtonDown("Fire1")){
      Shoot();
    }
  }
  
  void Shoot(){
    Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
  }
}



// Bullet script
using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public Rigidbody2D rb;
  public float speed = 20f;
  public int damage = 20;
  public GameObject hitEffect;
  
  void Start(){
    rb.velocity = transform.right * speed;
  }
  
  void OnTriggerEnter2D(Collider2D col){
    Enemy enemy = col.GetComponent<Enemy>();
    if(enemy != null){
      enemy.TakeDamage(damage);
    }
    Instantiate(hitEffect, transform.position, Quaternion.identity);
    Destroy(gameObject);
  }
}