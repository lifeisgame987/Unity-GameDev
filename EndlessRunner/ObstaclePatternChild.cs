using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class ObstaclePatternChild : MonoBehaviour{
  
  public GameObject obstaclePrefab;
  
  void Start(){
    Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
  }
}