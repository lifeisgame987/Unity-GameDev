using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public GameObject pinPrefab;
  
  void Start(){
    
  }
  
  void Update(){
    if(Input.GetMouseButtonDown(0)){
      Instantiate(pinPrefab, transform.position, transform.rotation);
    }
  }
}