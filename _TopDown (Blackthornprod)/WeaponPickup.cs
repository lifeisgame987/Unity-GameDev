using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class WeaponPickup : MonoBehaviour{
  
  [SerializeField] private Weapon weapon;
  
  void OnTriggerEnter2D(Collider2D col){
    if(col.CompareTag("Player")){
      col.GetComponent<Player>().ChangeWeapon(weapon);
      Destroy(gameObject);
    }
  }
}