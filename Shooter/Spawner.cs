using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class Spawner : MonoBehaviour{
  
  public float LMinX, LMaxX, LMinY, LMaxY;
  public float RMinX, RMaxX, RMinY, RMaxY;
  public float TMinX, TMaxX, TMinY, TMaxY;
  public float BMinX, BMaxX, BMinY, BMaxY;
  public int noOfEnemies;
  public GameObject enemy;
  private Vector2[] randomPosL;
  private Vector2[] randomPosR;
  private Vector2[] randomPosT;
  private Vector2[] randomPosB;
  private float timeBtwSpawn;
  public float startTimeBtwSpawn;
  
  void Start(){
    timeBtwSpawn = startTimeBtwSpawn;
    
    randomPosL = new Vector2[noOfEnemies];
    for(int i=0; i<randomPosL.Length; i++){
      randomPosL[i] = new Vector2(Random.Range(LMinX, LMaxX), Random.Range(LMinY, LMaxY));
    }
    
    randomPosR = new Vector2[noOfEnemies];
    for(int i=0; i<randomPosR.Length; i++){
      randomPosR[i] = new Vector2(Random.Range(RMinX, RMaxX), Random.Range(RMinY, RMaxY));
    }
    
    randomPosT = new Vector2[noOfEnemies];
    for(int i=0; i<randomPosT.Length; i++){
      randomPosT[i] = new Vector2(Random.Range(TMinX, TMaxX), Random.Range(TMinY, TMaxY));
    }
    
    randomPosB = new Vector2[noOfEnemies];
    for(int i=0; i<randomPosB.Length; i++){
      randomPosB[i] = new Vector2(Random.Range(BMinX, BMaxX), Random.Range(BMinY, BMaxY));
    }
  }
  
  void Update(){
    
    if(timeBtwSpawn <= 0f){
      int rand = Random.Range(0, noOfEnemies);
      Instantiate(enemy, randomPosL[rand], Quaternion.identity);
      Instantiate(enemy, randomPosR[rand], Quaternion.identity);
      Instantiate(enemy, randomPosT[rand], Quaternion.identity);
      Instantiate(enemy, randomPosB[rand], Quaternion.identity);
      timeBtwSpawn = startTimeBtwSpawn;
    }
   else{
      timeBtwSpawn -= Time.deltaTime;
    }
  }
}