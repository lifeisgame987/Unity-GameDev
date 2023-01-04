using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class Projectile : MonoBehaviour{
  
  [SerializeField] private float speed;
  [SerializeField] private int damage;
  [SerializeField] private float lifetime;
  [SerializeField] private GameObject explosion;
  
  void Start{
    Invoke("DestroyProjectile", lifetime);
  }
  
  void Update(){
    transform.Translate(Vector2.up * speed * Time.deltaTime);
  }
  
  void OnTriggerEnter2D(Collider2D col){
    if(col.CompareTag("Enemy")){
      col.GetComponent<Enemy>().TakeDamage(damage);
      Destroy(gameObject);
    }
  }
  
  void DestroyProjectile(){
    Instantiate(explosion, transform.position, Quaternion.identity);
    Destroy(gameObject);
  }
}