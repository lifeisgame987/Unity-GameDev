using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class Spwaner : MonoBehaviour{
  
  public GameObject[] obstaclePatternParentPrefab;
  public float seconds = 2f;
  public float lifeTime;
  
  void Start(){
    
  }
  
  void Update(){
    if(seconds >= 0.5f){
      Spawn();
    }
    else{
      Spawn();
      seconds = 0.5f + 0.01f;
    }
    seconds -= Time.deltaTime;
    
    /*
    if(timeBtwSpawn <= 0){
      Spawn();
      timeBtwSpawn = startTimeBtwSpawn;
      if(startTimeBtwSpawn > minTime){
        startTimeBtwSpawn -= decreaseTime;
      }
    }
    else{
      timeBtwSpawn -= Time.deltaTime;
    }
    */
  }
  
  private void Spwan(){
    int index = Random.Range(0, obstaclePatternParentPrefab.length);
    Instantiate(obstaclePatternParentPrefab[index], transform.position, Quaternion.identity);
  }
}