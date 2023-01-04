using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public Transform firePoint;
  public int damage = 20;
  public GameObject hitEffect;
  public LineRenderer lineRenderer;
  
  void Start(){
    lineRenderer.positionCount = 2;
  }
  
  void Update(){
    if(Input.GetButtonDown("Fire1")){
      Shoot();
    }
  }
  
  void Shoot(){
    RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
    if(hitInfo != null){
      Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
      if(enemy != null){
        enemy.TakeDamage(damage);
      }
      Instantiate(hitEffect, hitInfo.point, Quaternion.identity);
      
      lineRenderer.SetPosition(0, firePoint.position);
      lineRenderer.SetPosition(1, hitInfo.point);
    }
    else{
      lineRenderer.SetPosition(0, firePoint.position);
      lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
    }
  }
}