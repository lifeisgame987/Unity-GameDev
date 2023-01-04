using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  private bool isCutting = false;
  private CircleCollider2D col;
  public GameObject trailPrefab;
  private GameObject trailInstance;
  private Rigidbody2D rb;
  private Vector2 previousPos;
  
  void Start(){
    col = GetComponent<CircleCollider2D>();
    rb = GetComponent<Rigidbody2D>();
  }
  
  void Update(){
    
    if(Input.GetMouseButtonDown(0)){
      StartCutting();
    }
    else if(Input.GetMouseButtonUp(0)){
      StopCutting();
    }
    
    if(isCutting){
      UpdateCut();
    }
  }
  
  void UpdateCut(){
    // Unity recommends any object to be moved should have Rigidbody2D so that Unity can post process for better optimization
    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    rb.position = mousePos;
    
    // Since the object has Rigidbody2D, it is set to kinematic so that it doesn't fall but we have to get velocity so to enable collider we use Vector to do that
    float velocity = (mousePos - previousPos).magnitude * Time.deltaTime;
    if(velocity > minSpeed){
      col.enabled = true;
    }
    previousPos = mousePos;
  }
  
  void StartCutting(){
    isCutting = true;
    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    previousPos = mousePos;
    trailInstance = InstantiateInstantiate(trailPrefab, transform);
  }
  
  void StopCutting(){
    isCutting = false;
    col.enabled = false;
    trailInstance.transform.SetParent(null);
    Destroy(trailInstance, 1f);
  }
}