using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class SingletonManagers : MonoBehaviour{
  
  private static SingletonManagers _instance;
  
  public static SingletonManagers Instance{
    get{
      if(_instance == null){
        GameObject go = new GameObject("SingletonManagers");
        go.AddComponent<SingletonManagers>();
      }
      return _instance;
    }
  }
  
  public int Score{get; set;}
  public bool IsDead{get; set;}
  
  void Awake(){
    _instance = this;
  }
  
  void Start(){
    Score = 10;
    IsDead = false;
  }
}



// Another script
using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class Player : MonoBehaviour{
  
  void Start(){
    SingletonManagers.Instance.Score = 30;
    SingletonManagers.Instance.IsDead = true;
  }
}