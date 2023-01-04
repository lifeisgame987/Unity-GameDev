using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  private bool isPressed = false;
  public Rigidbody2D rb;
  public float releaseTime = 0.15f;
  public float maxDistance = 5f;
  public Rigidbody2D anchor;
  public float nextBirdTime = 2f;
  public GameObject nextBird;
  
  void Start(){
    
  }
  
  void Update(){
    if(isPressed){
      Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      if(Vector2.Distance(anchor.position, mousePos) >= maxDistance){
        rb.position = anchor.position + (mousePos - anchor.position).normalized * maxDistance;
      }
      else{
        rb.position = mousePos
      }
    }
  }
  
  void OnMouseDown(){
    isPressed = true;
    rb.isKinematic = true;
  }
  
  void OnMouseUp(){
    isPressed = false;
    rb.isKinematic = false;
    StartCoroutine(Release());
  }
  
  IEnumerator Release(){
    yield new return WaitForSeconds(releaseTime);
    GetComponent<SpringJoint2D>().enabled = false;
    this.enabled = false;
    
    yield return new WaitForSeconds(nextBirdTime);
    if(nextBird != null){
      nextBird.SetActive(true);
    }
    else{
      Enemy.NoOfEnemies = 0;
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
  }
}