using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  private class Wave{
    private Enemy[] enemies;
    private int size;
    private float timeBetweenSpawn;
  }
  
  [SerializeField] private Enemy[] enemies;
  [SerializeField] private Transform[] spawnPoints;
  [SerializeField] private GameObject player;
  [SerializeField] private float timeBetweenWaves;
  private bool finishedSpawning;
  
  private Wave GetWave(){
    int size = Random.Range(2, enemies.Length);
    Wave wave = new Wave();
    wave.enemies = new wave.Enemy[size];
    for(int i=0; i<size; i++){
      int rand = Random.Range(0, enemies.Length);
      wave.enemies[i] = enemies[rand];
    }
    wave.size = Random.Range(10, 31);
    wave.timeBetweenSpawn = Random.Range(1f, 2.1f);
    return wave;
  }
  
  void Start(){
    StartCoroutine(StartWave());
  }
  
  IEnumerator StartWave(){
    yield return new WaitForSeconds(timeBetweenWaves);
    StartCoroutine(SpawnEnemies());
  }
  
  IEnumerator SpawnEnemies(){
    Wave wave = GetWave();
    for(int i=0; i<wave.size; i++){
      if(player == null)
        yield break;
        
      Enemy randomEnemy = wave.enemies[Random.Range(0, wave.enemies.Length)];
      Transform randomSpot = spawnPoints[Random.Range(0, spawnPoints.Length)];
      Instantiate(randomEnemy, randomSpot.position, randomSpot.rotation);
      
      if(i == wave.size - 1)
        finishedSpawning = true;
      else
        finishedSpawning = false;
      yield return new WaitForSeconds(wave.timeBetweenSpawn);
    }
  }
  
  void Update(){
    if(finishedSpawning && GameObject.FindGameObjectsWithTag("Enemy")==0){
      finishedSpawning = false;
      StartCoroutine(StartWave());
    }
  }
}