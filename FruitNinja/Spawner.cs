using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public Transform[] spawnPoints;
  public float minDelay = 0.5f;
  public float maxDelay = 1.5f;
  public GameObject fruitPrefab;
  
  void Start(){
    StartCoroutine(Spawn);
  }
  
  IEnumerator Spawn(){
    while(true){
      float delay = Random.Range(minDelay, maxDelay);
      yield return new WaitForSeconds(delay);
      
      int i = Random.Range(0, spawnPoints.Length);
      InstantiateInstantiate(fruitPrefab, spawnPoints[i], spawnPoints[i].rotation);
    }
  }
}