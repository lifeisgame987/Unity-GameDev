using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public Transform player;
  
  void LateUpdate(){
    if(player.position.y > transform.position.y){
      transform.position = new Vector2(transform.position.x, player.position.y);
    }
  }
}