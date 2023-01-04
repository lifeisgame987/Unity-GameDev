using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class Enums : MonoBehaviour{
  
  public enum EnemyState{
    Searching,
    Attacking,
    Dead,
  }
  
  public EnemyState currentEnemyState;
  
  void Start(){
    currentEnemyState = EnemyState.Searching;
  }
  
  void Update(){
    switch(currentEnemyState){
      case EnemyState.Searching:
        Debug.Log("Searching...");
        break;
      case EnemyState.Attacking:
        Debug.Log("Attacking...");
        break;
      case EnemyState.Dead:
        Debug.Log("Dead...");
        break;
    }
  }
}



// Another script
using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class EnumExample : MonoBehaviour{
  
  private Enums _enum;
  
  void Start(){
    _enum = GetComponent<Enums>();
  }
  
  void Update(){
    if(Input.GetKeyDown(KeyCode.Space)){
      _enum.currentEnemyState = Enums.EnemyState.Dead;
      
      // OR randomise state
      _enum.currentEnemyState = (Enums.EnemyState) Random.Range(0, 3);
    }
  }
}