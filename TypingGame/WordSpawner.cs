using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public GameObject wordPrefab;
  public Transform canvas;
  
  public WordDisplay SpawnWord(){
    Vector3 randomPos = new Vector3(Random.Range(-2.5f, 2.5f), 8f);
    GameObject instance = Instantiate(wordPrefab, randomPos, Quaternion.identity, canvas);
    WordDisplay wordDisplay = instance.GetComponent<WordDisplay>();
    return wordDisplay;
  }
}