using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class TrailEffects : MonoBehaviour{
  
  public float timeBtwSpawn;
  public float startTimeBtwSpawn;
  // Animate the gameObject which you want to trail behind your MAIN gameObject and then make it prefab
  public GameObject trailPrefab;
  private PlayerScript playerMove;
  
  void Start(){
    playerMove = GetComponent<PlayerScript>();
  }
  
  void Update(){
    if(playerMove.moveInput != 0){
      if(timeBtwSpawn <= 0){
        GameObject instance = (GameObject) InstantiateInstantiate(trailPrefab, transform.position, Quaternion.identity);
        Destroy(instance, 8f);
        timeBtwSpawn = startTimeBtwSpawn;
      }
      else{
        timeBtwSpawn -= Time.deltaTime;
      }
    }
  }
}

// Normal line trail can be done through TrailRenderer COMPONENT


using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class TrailEffects : MonoBehaviour{
  
  public float timeBtwSpawn;
  public float startTimeBtwSpawn;
  // If you want to trail different sprites behind the MAIN gameObject then make different sprite gameObject prefab
  public GameObject[] diffTrailPrefabs;
  private PlayerScript playerMove;
  
  void Start(){
    playerMove = GetComponent<PlayerScript>();
  }
  
  void Update(){
    if(playerMove.moveInput != 0){
      if(timeBtwSpawn <= 0){
        float rand = Random.Range(0, diffTrailPrefabs.length);
        GameObject instance = (GameObject) Instantiate(diffTrailPrefabs[rand], transform.position, Quaternion.identity);
        Destroy(instance, 8f);
        timeBtwSpawn = startTimeBtwSpawn;
      }
      else{
        timeBtwSpawn -= Time.deltaTime;
      }
    }
  }
}