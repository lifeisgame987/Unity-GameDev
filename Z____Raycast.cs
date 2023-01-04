using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public float distance = 100f;
  public Transform enemy;
  public LineRenderer line;
  public Gradient colorGreen;
  public Gradient colorRed;
  
  void Start(){
    // If (this) GameObject has collider it will ignore it and won't block the raycast to cast it ray to the desired direction at a given distance;
    Physics2D.queriesStartInColliders = false;
    line.positionCount = 2;
  }
  
  void Update(){
    Raycast();
    LookAtEnemy();
  }
  
  void LookAtEnemy(){
    Vector2 dir = enemy.position - transform.position;
    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    transform.rotation = Quaternion.AngleAxis(Vector3.forward, angle);
  }
  
  void Raycast(){
    RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
    if(hitInfo != null){
      if(hitInfo.collider.CompareTag("Enemy")){
        Debug.DrawLine(transform.position, hitInfo.point, Color.green);
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hitInfo.point);
        line.colorGradient = colorGreen;
      }
      else{
        Debug.DrawLine(transform.position, hitInfo.point, Color.red);
        line.SetPosition(0, transform.position);
        line.SetPosition(1, hitInfo.point);
        line.colorGradient = colorRed;
      }
    }
    else{
      Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.red);
      line.SetPosition(0, transform.position);
      line.SetPosition(1, transform.position + transform.right * distance);
      line.colorGradient = colorRed;
    }
  }
}