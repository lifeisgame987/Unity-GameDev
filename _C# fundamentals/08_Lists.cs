using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public List<int> ages = new List<int>();
  public List<GameObject> objects = new List<GameObject>();
  public List<string> strings = new List<string>();
  
  void Update(){
    
    if(Input.GetKeyDown(KeyCode.Space)){
      ages.Add(Random.Range(1, 100));
    }
    
    if(Input.GetKeyDown(KeyCode.Q) && ages.Count>0){
      ages.Remove(Random.Range(0, ages.Count));
    }
  }
}