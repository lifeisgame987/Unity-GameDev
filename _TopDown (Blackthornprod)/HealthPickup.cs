using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class HealthPickup : MonoBehaviour{
  
  private Player playerScript;
  [SerializeField] private int healAmount;
  
  void Start(){
    playerScript = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
  }
  
  void OnTriggerEnter2D(Collider2D col){
    if(col.CompareTag("Player")){
      playerScript.Heal(healAmount);
      Destroy(gameObject);
    }
  }
}