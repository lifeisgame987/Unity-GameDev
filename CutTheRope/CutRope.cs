using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  void Update(){
    if(Input.GetMouseButton(0)){
      Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
      RaycastHit2D hitInfo = Physics2D.Raycast(mousePos, Vector2.zero);
      if(hitInfo.collider != null){
        if(hitInfo.collider.CompareTag("Link")){
          Destroy(hitInfo.collider.gameObject);
          // Destroy the anchor point after few sec
          Destroy(hitInfo.transform.parent.gameObject, 2f);
        }
      }
    }
  }
}