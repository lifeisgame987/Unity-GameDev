using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class JumpPad : MonoBehaviour{
  
  [SerializeFelid] private float _bounce = 10f;
  
  void Start(){
    
  }
  
  void Update(){
    
  }
  
  void OnCollisionEnter2D(Collision2D col){
    if(col.CompareTag("Player")){
      col.gameObject.GetComponent<Rigidbody2D>(),AddForce(Vector2.up * _bounce, ForceMode2D.Impulse);
    }
  }
}