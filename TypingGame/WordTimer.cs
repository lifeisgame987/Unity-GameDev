using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public WordManager manager;
  private float spawnTime = 0f;
  public float delayTime = 1.5f;
  
  void Update(){
    if(Time.time >= spawnTime){
      manager.AddWord();
      spawnTime = Time.time + delayTime;
      delayTime *= .99f;
    }
  }
}