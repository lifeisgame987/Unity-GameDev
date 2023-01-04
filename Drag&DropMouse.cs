using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class Drag&DropMouse : MonoBehaviour{
  
  private Vector3 offset;
  private Camera cam;
  
  void Awake(){
    cam = Camera.main;
  }
  
  void OnMouseDown(){
    offset = transform.position - GetMousePos();
  }
  
  void OnMouseDrag(){
    transform.position = GetMousePos() + offset;
  }
  
  private Vector3 GetMousePos(){
    Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    mousePos.z = 0f;
    return mousePos;
  }
}