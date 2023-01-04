using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class SpawnerNew : MonoBehaviour{
  
  private float timeBtwSpawn;
  public float startTimeBtwSpawn;
  private Vector2 randPos;
  public float LMinX, LMaxX, LMinY, LMaxY;
  public float RMinX, RMaxX, RMinY, RMaxY;
  public float TMinX, TMaxX, TMinY, TMaxY;
  public float BMinX, BMaxX, BMinY, BMaxY;
  private int noOfEnemiesSpawned = 1;
  public int totalNoOfEnemies;
  public GameObject enemy;
  
  void Start(){
    timeBtwSpawn = startTimeBtwSpawn;
  }
  
  void Update(){
    if(timeBtwSpawn <= 0f){
      if(noOfEnemiesSpawned <= totalNoOfEnemies){
        int rand = Random.Range(0, 4);
        if(rand==0){
          randPos = RandomPos(LMinX, LMaxX, LMinY, LMaxY);
        }
        else if(rand==1){
          randPos = RandomPos(RMinX, RMaxX, RMinY, RMaxY);
        }
        else if(rand==2){
          randPos = RandomPos(TMinX, TMaxX, TMinY, TMaxY);
        }
        else{
          randPos = RandomPos(BMinX, BMaxX, BMinY, BMaxY);
        }
        
        Instantiate(enemy, randPos, Quaternion.identity);
        noOfEnemiesSpawned++;
      }
      
      timeBtwSpawn = startTimeBtwSpawn;
    }
    else{
      timeBtwSpawn -= Time.deltaTime;
    }
  }
  
  private Vector2 RandomPos(float minX, float maxX, float minY, float maxY){
    float randX = Random.Range(minX, maxX);
    float randY = Random.Range(minY, maxY);
    return new Vector2(randX, randY);
  }
}