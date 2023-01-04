using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class TouchControls : MonoBehaviour{
  
  void Start(){
    
  }
  
  void Update(){
    if(Input.touchCount > 0){
      // Get first touch and store it in variable
      Touch touch = Input.GetTouch(0);
      
      // Change touch pixel coordinates into unity world units coordinates
      Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
      
      // 2D doesn't require z axis so resetting to 0
      touchPosition.z = 0f;
      
      // Placing current object position to touch position
      transform.position = touchPosition;
    }
  }
}


using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class TouchControls : MonoBehaviour{
  
  void Start(){
    
  }
  
  void Update(){
    for(int i=0; i<Input.touchCount; i++){
      Touch touch = Input.touches[i];
      Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
      Debug.DrawLine(Vector3.zero, touchPosition, Color.red);
    }
  }
} // Enable GISMOZE to see line through Debug.DrawLine();