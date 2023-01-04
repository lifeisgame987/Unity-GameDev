using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public Rigidbody2D rb;
  public float shrinkSpeed = 3f;
  
  void Start(){
    rb.rotation = Random.Range(0f, 360f);
    transform.localScale = new Vector3(30f, 30f, 0f);
  }
  
  void Update(){
    transform.localScale -= Vector3.one * shrinkSpeed * Time.deltaTime;
    if(transform.localScale.x <= 2f){
      Destroy(gameObject);
    }
  }
}