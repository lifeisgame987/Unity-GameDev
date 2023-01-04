using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public float spawnRate = 1f
  public gameObject hexagonPrefab;
  public float nextTimeToSpawn = 0f;
  
  void Update(){
    if(Time.time >= nextTimeToSpawn){
      Instantiate(hexagonPrefab, Vector3.zero, Quaternion.identity);
      nextTimeToSpawn = Time.time + 1f / spawnRate;
    }
  }
}