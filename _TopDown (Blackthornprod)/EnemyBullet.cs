using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class EnemyBullet : MonoBehaviour{
  
  [SerializeField] private float speed;
  [SerializeField] private int damage;
  private Player playerScript;
  private Vector2 targetPosition;
  
  void Start(){
    playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    targetPosition = playerScript.transform.position;
  }
  
  void Update(){
    if(player != null){
      if(Vector2.Distance(transform.position, targetPosition) > .1f){
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
      }
      else{
        Destroy(gameObject);
      }
    }
  }
  
  void OnTriggerEnter2D(Collider2D col){
    if(col.CompareTag("Player")){
      playerScript.TakeDamage(damage);
      Destroy(gameObject);
    }
  }
}