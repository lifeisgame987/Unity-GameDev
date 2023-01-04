using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public Transform[] spawnPoints;
  public GameObject blockPrefab;
  public float timeToSpawn = 2f;
  public float waitTime = 1f;
  
  void Update(){
    if(Time.time >= timeToSpawn){
      SpawnBlocks();
      timeToSpawn = Time.time + waitTime;
    }
  }
  
  void SpawnBlocks(){
    int index = Random.Range(0, spawnPoints.Length);
    for(int i=0; i<spawnPoints.Length; i++){
      if(i != index){
        Instantiate(blockPrefab, spawnPoints[i].position, Quaternion.identity);
      }
    }
  }
}