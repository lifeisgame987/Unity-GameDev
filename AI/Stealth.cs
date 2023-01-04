using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class Stealth : MonoBehaviour{
  
  public float rotationSpeed;
  public float distance;
  private LineRenderer line;
  public Gradient colorRed;
  public Gradient colorGreen;
  
  void Start(){
    // For Raycast not to detect its own collider
    Physics2D.queriesStartInColliders = false;
    
    line = GetComponent<LineRenderer>();
    line.positionCount = 2f;
    line.SetPosition(0, transform.position);
  }
  
  void Update(){
    transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    
    RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
    
    if(hitInfo.collider != null){
      Debug.DrawLine(transform.position, hitInfo.point, Color.red);
      line.SetPosition(1, hitInfo.point);
      line.colorGradient = colorRed;
      
      if(hitInfo.collider.CompareTag("Player")){
        Destroy(hitInfo.collider.gameObject);
      }
    }
    else{
      Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
      line.SetPosition(1, transform.position + transform.right * distance);
      line.colorGradient = colorGreen;
    }
  }
}