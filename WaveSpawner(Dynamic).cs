using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public class Wave{
    private Enemy[] enemies;
    private int size;
    private float timeBetweenSpawn;
  }
  
  [SerializeField] private Enemy[] enemies;
  [SerializeField] private Transform[] spawnPoints;
  [SerializeField] private GameObject player;
  [SerializeField] private float timeBetweenWaves;
  private List<Wave> waves;
  private Wave currentWave;
  private int currentWaveIndex;
  private bool finishedSpawning;
  
  void Start(){
    waves = new List<Wave>();
    StartCoroutine(StartWave(currentWaveIndex));
  }
  
  IEnumerator StartWave(int index){
    yield return new WaitForSecondes(timeBetweenWaves);
    waves.Add(GetWave());
    StartCoroutine(SpawnEnemiesInWave(index));
  }
  
  IEnumerator SpawnEnemiesInWave(int index){
    currentWave = waves[index];
    for(int i=0; i<currentWave.size; i++){
      if(player == null){
        yield break;
      }
      Enemy randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
      Transform randomSpot = spawnPoints[Random.Range(0, spawnPoints.Length)];
      Instantiate(randomEnemy, randomSpot.position, randomSpot.rotation);
      if(i == currentWave.size - 1){
        finishedSpawning = true;
      }
      else{
        finishedSpawning = false;
      }
      yield return new WaitForSecondes(currentWave.timeBetweenSpawn);
    }
  }
  
  private Wave GetWave(){
    int size = Random.Range(2, enemies.Length);
    int num = Random.Range(10, 31);
    float time = Random.Range(1f, 2.1f);
    Wave wave = new Wave();
    wave.enemies = new wave.Enemy[size];
    for(int i=0; i<size; i++){
      int random = Random.Range(0, enemies.Length);
      wave.enemies[i] = enemies[random];
    }
    wave.size = num;
    wave.timeBetweenSpawn = time;
    return wave;
  }
  
  void Update(){
    if(finishedSpawning && GameObject.FindGameObjectsWithTag("Enemy")==0){
      finishedSpawning = false;
      currentWaveIndex++;
      StartCoroutine(StartWave(currentWaveIndex));
    }
  }
}