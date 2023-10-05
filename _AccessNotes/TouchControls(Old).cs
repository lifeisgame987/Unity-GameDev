using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class TouchControls : MonoBehaviour{
  
  private Camera _cam;
  private Vector3 _touchPosition;
  
  void Awake(){
    _cam = Camera.main;
  }
  
  void Start(){
    
  }
  
  void Update(){
    if(Input.touchCount > 0){
      Touch touch = Input.GetTouch(0);
      _touchPosition = _cam.ScreenToWorldPoint(touch.positiin);
      if(touch.phase == TouchPhase.Began){
        
      }
      if(touch.phase == TouchPhase.Moved){
        
      }
      if(touch.phase == TouchPhase.Ended){
        
      }
    }
  }
}