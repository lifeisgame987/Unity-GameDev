using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public float minX, maxX;
  public GameObject textObj;
  public Transform canvas;
  public WordManager manager;
  
  private float spawnTime = 0f;
  public float delayTime = 1.5f;
  
  void Update(){
    if(Time.time >= spawnTime){
      Vector3 pos = new Vector3(Random.Range(minX, maxX), 7f);
      Instantiate(textObj, pos, Quaternion.identity, canvas);
      
      // Doubt check to see if it works
      manager.AddWord();
      
      
      spawnTime = Time.time + delayTime;
      delayTime *= .99f;
    }
  }
}