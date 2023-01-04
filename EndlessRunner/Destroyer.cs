using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class Destroyer : MonoBehaviour{
  
  public float lifetime;
  
  void Start(){
    Destroy(gameObject, lifetime);
  }
  
  void Update(){
    
  }
}
// Attached to ObstaclePrefab, ObstaclePatternParentPrefab