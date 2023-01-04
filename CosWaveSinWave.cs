using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class CosWaveSinWave : MonoBehaviour{
  
  public float amplitude;
  public float frequency;
  
  void Start(){
    
  }
  
  void Update(){
    float x = Mathf.Cos(Time.time * frequency) * amplitude;
    float y = Mathf.Sin(Time.time * frequency) * amplitude;
    
    transform.position = new Vector2(x, y);
  }
}