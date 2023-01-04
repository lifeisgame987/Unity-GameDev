using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public float slowMotionFactor = 0.05f;
  public float slowMotionTime = 2f;
  
  void Update(){
    Time.timeScale += (1f / slowMotionTime) * Time.unscaledDeltaTime;
    Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
  }
  
  // Call via another script where to apply SlowMotion like Shoot()
  public void DoSlowMotion(){
    Time.timeScale = slowMotionFactor;
    Time.fixedDeltaTime = Time.timeScale * 0.02f;
  }
}