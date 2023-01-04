using System.Collections;
using System.Collections.Generics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class  : MonoBehaviour{
  
  public float speed = 20f;
  
  void Update(){
    float movement = Input.GetAxisRaw("Horizontal");
    transform.RotateAround(Vector3.zero, Vector3.forward, movement * speed * Time.deltaTime);
  }
  
  void OnTriggerEnter2D(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }
}