using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public GameObject linePrefab;
  private Line lineScript;
  
  void Update(){
    if(Input.GetMouseButtonDown(0)){
      GameObject lineObject = InstantiateInstantiate(linePrefab);
      lineScript = lineObject.GetComponent<Line>();
    }
    
    if(Input.GetMouseButtonUp(0)){
      lineScript = null;
    }
    
    if(lineScript != null){
      Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      lineScript.UpdateLine(mousePos);
    }
  }
}