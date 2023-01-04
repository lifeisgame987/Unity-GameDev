using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  private Rigidbody2D rb;
  public float speed = 10f;
  public GameObject slice;
  
  void Start(){
    rb = GetComponent<Rigidbody2D>();
    rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
  }
  
  void OnTriggerEnter2D(Collider2D collider){
    if(collider.CompareTag("Blade")){
      
      Vector2 dir = collider.transform.position - transform.position;
      Quaternion rotation = Quaternion.LookRotation(dir);
      
      GameObject instance = Instantiate(slice, transform.position, rotation);
      Destroy(instance, 3f);
      Destroy(gameObject);
    }
  }
}