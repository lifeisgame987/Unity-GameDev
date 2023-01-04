using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class LaunchPath : MonoBehaviour{
  
  public Transform shotPoint;
  public GameObject point;
  private GameObject[] points;
  private Vector2 direction;
  
  public int noOfPoints;
  public float spaceBtwPoints;
  public float launchForce;
  
  void Start(){
    points = new GameObject[noOfPoints];
    for(int i=0; i<noOfPoints; i++){
      points[i] = Instantiate(point, shotPoint.poistion, Quaternion.identity);
    }
  }
  
  void Update(){
    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    direction = mousePos - shotPoint.position;
    
    for(int i=0; i<noOfPoints; i++){
      points[i].transform.position = PointPosition(i * spaceBtwPoints);
    }
  }
  
  private Vector2 PointPosition(float t){
    Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
    return position;
  }
}