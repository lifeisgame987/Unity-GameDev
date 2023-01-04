using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public GameObject playerPrefab;
  public int noOfPlatforms = 200;
  public float minY = .5f;
  public float maxY = 2.5f;
  public float levelWidth = 3f;
  
  void Start(){
    for(int i=0; i<noOfPlatforms; i++){
      Vector2 pos = new Vector2(Random.Range(-levelWidth, levelWidth), Random.Range(minY, maxY));
      Instantiate(playerPrefab, pos, Quaternion.identity);
    }
  }
}