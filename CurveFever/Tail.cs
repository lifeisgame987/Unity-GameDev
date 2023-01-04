using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public Transform head;
  public float pointsSpacing = 0.1f;
  List<Vector2> points;
  private LineRenderer line;
  private EdgeCollider2D col;
  
  void Start(){
    points = new List<Vector2>();
    line = GetComponent<LineRenderer>();
    col = GetComponent<EdgeCollider2D>();
    
    SetPoints(head.position);
  }
  
  void Update(){
    if(Vector2.Distance(points[points.Count-1].position, head.position) > pointsSpacing){
      SetPoints(head.position);
    }
  }
  
  void SetPoints(Vector2 pos){
    // It has to be done first as otherwise it will collide with the head's collider and there will be collision error
    if(points.Count > 1){
      col.points = points.ToArray<Vector2>();
    }
    
    points.Add(pos);
    
    line.positionCount = points.Count;
    line.SetPosition(points.Count-1, pos);
  }
}