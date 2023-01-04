using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  private LineRenderer lineRend;
  private EdgeCollider2D edgeCol;
  List<Vector2> points;
  
  void Start(){
    lineRend = GetComponent<LineRenderer>();
    edgeCol = GetComponent<EdgeCollider2D>();
  }
  
  public void UpdateLine(Vector2 mousePos){
    if(points == null){
      points = new List<Vector2>();
      SetPoints(mousePos);
      return;
    }
    
    // Check if mouse has moved from initial position
    // If it has: Insert more points
    if(Vector2.Distance(points[points.Count-1], mousePos) > 0.1f){
      SetPoints(mousePos);
    }
    
    /* CAN ALSO BE DONE THROUGH ---->
    if(Vector2.Distance(points.Last(), mousePos) > 0.1f){
      SetPoints(mousePos);
    } using System.Linq;
    */
  }
  
  private void SetPoints(Vector2 point){
    points.Add(point);
    
    lineRend.positionCount = points.Count;
    lineRend.SetPosition(points.Count-1, point);
    
    if(points.Count > 1){
      edgeCol.points = points.ToArray();
    }
  }
}

// Set collision detection in INSPECTER from (discrete) to (continuous)