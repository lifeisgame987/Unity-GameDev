using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class Nudge : MonoBehaviour{
  
  [SerializeField] private float _nudgeAccel;
  
  [SerializeField] private Transform _topRightEdge;
  [SerializeField] private Transform _topRightEdgeThreshold;
  [SerializeField] private Transform _topLeftEdge;
  [SerializeField] private Transform _topLeftEdgeThreshold;
  [SerializeField] private Transform _rightBottomEdge;
  [SerializeField] private Transform _rightBottomEdgeThreshold;
  
  [SerializeField] private LayerMask _ledgeLayer;
  
  void Start(){
    
  }
  
  void Update(){
    
  }
  
  void OnCollisionEnter2D(Collider2D col){
    if(col.CompareTag("Ledge")){
      if(HasCollided(_topRightEdge, Vector2.up) && !HasCollided(_topRightEdgeThreshold, Vector2.up)){
        Vector3 dir = _topRightEdgeThreshold.position - _topRightEdge.position;
        transform.position += dir.normalized * _nudgeAccel * Time.deltaTime;
      }
      if(HasCollided(_topLeftEdge, Vector2.up) && !HasCollided(_topLeftEdgeThreshold, Vector2.up)){
        Vector3 dir = _topLeftEdgeThreshold.position - _topLeftEdge.position;
        transform.position += dir.normalized * _nudgeAccel * Time.deltaTime;
      }
      if(HasCollided(_rightBottomEdge, Vector2.right) && !HasCollided(_rightBottomEdgeThreshold, Vector2.right)){
        Vector3 dir = _rightBottomEdgeThreshold.position - _rightBottomEdge.position;
        transform.position += dir.normalized * _nudgeAccel * Time.deltaTime;
      }
    }
  }
  
  private bool HasCollided(Transform edge, Vector2 dir){
    return Physics2D.Raycast(edge.position, dir, 1f, _ledgeLayer);
  }
}