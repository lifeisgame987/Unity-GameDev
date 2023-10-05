using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour{
  
  public static InputManager Instance {get; private set}
  
  private void Awake(){
    if(Instance != null){
      Destroy(gameObject);
    }
    Instance = this;
  }
  
  public Vector2 GetInputPosition(){
    return Camera.main.ScreenToWorldPoint(Input.mousePosition);
  }
}