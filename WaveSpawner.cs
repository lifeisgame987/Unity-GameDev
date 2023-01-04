using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  [System.Serializable]
  public class Wave{
    public Enemy[] enemies;
    public int size;
    public float timeBetweenSpawn;
  }
  
  [SerializeField] private Wave[] waves;
  [SerializeField] private Transform[] spawnPoints;
  [SerializeField] private float timeBetweenWaves;
  [SerializeField] private GameObject player;
  private Wave currentWave;
  private int currentWaveIndex;
  private bool finishedSpawning;
  
  void Start(){
    StartCoroutine(StartWave(currentWaveIndex));
  }
  
  IEnumerator StartWave(int index){
    yield return new WaitForSeconds(timeBetweenWaves);
    StartCoroutine(SpawnEnemiesInWave(index));
  }
  
  IEnumerator SpawnEnemiesInWave(int index){
    currentWave = waves[currentWaveIndex];
    
    for(int i=0; i<currentWave.size; i++){
      if(player == null)
        yield break;
      
      Enemy randomEnemy = currentWave.enemies[0, currentWave.enemies.Length];
      Transform randomSpot = spawnPoints[Random Range(0, spawnPoints.Length)];
      
      Instantiate(randomEnemy, randomSpot.position, randomSpot.rotation);
      
      if(i == currentWave.size - 1)
        finishedSpawning = true;
      else
        finishedSpawning = false;
      
      yield return new WaitForSeconds(currentWave.timeBetweenSpawn);
    }
  }
  
  void Update(){
    if(finishedSpawning && GameObject.FindObjectsWithTag("Enemy").Length == 0){
      finishedSpawning = false;
      if(currentWaveIndex + 1 < waves.Length){
        currentWaveIndex++;
        StartCoroutine(StartWave(currentWaveIndex));
      }
      else{
        Debug.Log("GAME FINISHED");
      }
    }
  }
}