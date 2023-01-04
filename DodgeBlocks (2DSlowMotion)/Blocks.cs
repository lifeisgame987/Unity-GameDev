using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  void Start(){
    GetComponent<Regidbody2D>().gravityScale += Time.timeSinceLevelLoad / 20f;
  }
  
  void Update(){
    if(transform.position.y <= -2f){
      Destroy(gameObject);
    }
  }
}