using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class WaveSpawner : MonoBehaviour{
  
  [System.Serializable]
  public class Wave{
    public Enemy[] ememies;
    public int count;
    public float timeBetweenSpawn;
  }
  
  [SerializeField] private Wave[] waves;
  [SerializeField] private float timeBetweenWave;
  [SerializeField] private Transform[] spawnPoints;
  private int currentWaveIndex;
  private Transform player;
  private Wave currentWave;
  private bool finishedSpawning;
  
  void Start(){
    player = GameObject.FindGameObjectWithTag("Player").transform;
    StartCoroutine(StartNextWave(currentWaveIndex));
  }
  
  IEnumerator StartNextWave(int index){
    yield return new WaitForSeconds(timeBetweenWave);
    StartCoroutine(SpawnWave(index));
  }
  
  IEnumerator SpawnWave(int index){
    currentWave = waves[index];
    
    for(int i=0; i<currentWave.count; i++){
      if(player == null)
        yield break;
      
      Enemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
      Transform randomSpot = spawnPoints[Random.Range(0, spawnPoints.Length)];
      
      Instantiate(randomEnemy, randomSpot.position, randomSpot.rotation);
      
      if(i == currentWave.count - 1)
        finishedSpawning = true;
      else
        finishedSpawning = false;
      
      yield return new WaitForSeconds(currentWave.timeBetweenSpawn);
    }
  }
  
  void Update(){
    if(finishedSpawning && GameObject.FindGameObjectsWithTag("Enemy") == 0){
      finishedSpawning = false;
      if(currentWaveIndex + 1 < waves.Length){
        currentWaveIndex++;
        StartCoroutine(StartNextWave(currentWaveIndex));
      }
      else{
        Debug.Log("GAME FINISHED");
      }
    }
  }
}