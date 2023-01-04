using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class Enemy : MonoBehaviour{
  
  public int health;
  public float speed;
  public float AttackTime;
  public float timeBetweenAttack;
  public Transform player;
  public int damage;
  public int pickupChance;
  public GameObject[] pickups;
  
  public virtual void Start(){
    player = GameObject.FindGameObjectWithTag("Player").transform;
  }
  
  public void TakeDamage(int damage){
    health -= damage;
    if(health <= 0){
      int randomChance = Random.Range(0, 101);
      if(pickupChance < randomChance){
        GameObject randomPickup = pickups[Random.Range(0, pickups.Length)];
        Instantiate(randomPickup, transform.position, transform.rotation);
      }
      
      Destroy(gameObject);
    }
  }
}