using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  private float timeBtwSpawn;
  public float startTimeBtwSpawn = 1.5f;
  public GameObject carPrefab;
  public Transform[] spawnPoints;
  
  void Start(){
    timeBtwSpawn = startTimeBtwSpawn;
  }
  
  void Update(){
    if(timeBtwSpawn <= 0f){
      SpawnCar();
      timeBtwSpawn = startTimeBtwSpawn;
    }
    else{
      timeBtwSpawn -= Time.deltaTime;
    }
  }
  
  void SpawnCar(){
    int ind = Random.Range(0, spawnPoints.Length);
    Transform spawnPoint = spawnPoints[ind];
    Instantiate(carPrefab, spawnPoint.position, spawnPoint.rotation);
  }
}