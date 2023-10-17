using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour{
  
  public static InputManager Instance {get; private set}
  
  private Vector2 _mousePosition;
  private bool _isMouseClicked;
  
  private void Awake(){
    Instance = this;
  }
  
  private void Update(){
    _isMouseClicked = Input.GetMouseButtonDown(0);
    
    if(_isMouseClicked){
      _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
  }
  
  public bool IsMouseClicked(){
    return _isMouseClicked;
  }
  
  public Vector2 GetInputPosition(){
    return _mousePosition;
  }
}