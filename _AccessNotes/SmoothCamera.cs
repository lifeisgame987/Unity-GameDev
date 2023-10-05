using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class SmoothCamera : MonoBehaviour{
  
  private Vector3 _velocity = Vector3.zero;
  
  [SerializeField] private float _smoothness = 0.25f;
  [SerializeField] private Vector3 _offset = new Vector3(0f, 0f, -10f);
  [SerializeField] private Transform _target;
  
  void Start(){
    
  }
  
  void Update(){
    
  }
  
  void LateUpdate(){
    Vector3 targetPosition = _target.position + _offset;
    transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, _smoothness);
  }
}