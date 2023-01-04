using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public Transform player;
  public static bool IsFired;
  public float speed = 5f;
  
  void Start(){
    IsFired = false;
  }
  
  void Update(){
    if(Input.GetButtonDown("Fire1")){
      IsFired = true;
    }
    
    if(IsFired){
      transform.localScale.y += Time.deltaTime * speed;
    }
    else{
      transform.position = player.position;
      transform.localScale = new Vector3(1f, 0f, 1f);
    }
  }
}