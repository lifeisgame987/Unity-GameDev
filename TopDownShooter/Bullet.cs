using System.Collections;
using System.Collections.Generics;
using UnityEngine;

[RequireComponent(typeOf(Rigidbody2D))]
public class  : MonoBehaviour{
  
  private Rigidbody2D rb;
  public float bulletSpeed = 20f;
  public GameObject hitEffect;
  
  void Start(){
    rb = GetComponent<Rigidbody2D>();
    rb.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
  }
  
  void OnCollisionEnter2D(Collision2D colInfo){
    Instantiate(hitEffect, transform.position, Quaternion.identity);
    Destroy(gameObject);
  }
}