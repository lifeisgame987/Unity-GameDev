using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public float speed = 5f
  public float rotationSpeed = 200f;
  private float horizontal = 0f;
  public string axisName = "Horizontal";
  
  void Update(){
    horizontal = Input.GetAxisRaw(axisName);
  }
  
  void FixedUpdate(){
    transform.Translate(Vector2.up * speed * Time.fixedDeltaTime, Space.Self);
    transform.Rotate(Vector3.forward * -horizontal * rotationSpeed * Time.fixedDeltaTime);
  }
  
  void OnTriggerEnter2D(Collider2D col){
    if(col.CompareTag("KillableObjects")){
      speed = 0f;
      rotationSpeed = 0f;
      GameManager.instance.Reload();
    }
  }
}