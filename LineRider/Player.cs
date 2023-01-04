using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  private Rigidbody2D rb;
  
  void Start(){
    rb = GetComponent<Rigidbody2D>();
  }
  
  void Update(){
    if(Input.GetButtonDown("Jump")){
      // Setting the default Rigidbody2D Static to Dynamic on player input
      rb.bodyType = RigidbodyType2D.Dynamic;
    }
  }
}