using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class Weapon : MonoBehaviour{
  
  [SerializeField] private GameObject projectile;
  [SerializeField] private Transform shotPoint;
  [SerializeField] private float timeBetweenShot;
  private float shotTime;
  
  void Update(){
    Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg -90;
    Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    transform.rotation = rotation;
    
    if(Time.time >= shotTime){
      if(Input.GetMouseButtonDown(0)){
        Instantiate(projectile, shotPoint.position, transform.rotation);
        shotTime = Time.time + timeBetweenShot;
      }
    }
  }
}