using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public float health = 4f;
  public GameObject deathEffect;
  public static int NoOfEnemies = 0;
  
  void Start(){
    NoOfEnemies++;
  }
  
  void OnCollisionEnter2D(Collision2D colInfo){
    if(colInfo.relativeVelocity.magnitude >= health){
      Instantiate(deathEffect, transform.position, Quaternion.identity);
      NoOfEnemies--;
      if(noOfEnemies <= 0){
        Debug.Log("Level won");
      }
      Destroy(gameObject);
    }
  }
}