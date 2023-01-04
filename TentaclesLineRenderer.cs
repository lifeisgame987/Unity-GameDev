using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class TentaclesLineRenderer : MonoBehaviour{
  
  public int length;
  private Vector3[] segmentPoses;
  private LineRenderer lineRend;
  public Transform targetDir;
  public float targetDistance;
  private Vector3[] segmentV;
  public float smoothSpeed;
  public float trailSpeed;
  
  public float wiggleSpeed;
  public float wiggleMagnitude;
  public Transform wiggleDir;
  
  void Start(){
    lineRend = GetComponent<LineRenderer>();
    segmentPoses = new Vector3[length];
    lineRend.positionCount = length;
  }
  
  void Update(){
    
    wiggleDir.localRotation = Quaternion.Euler(0f, 0f, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);
    
    segmentPoses[0] = targetDir;
    for(int i=1; i<segmentPoses.Length; i++){
      segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], segmentPoses[i-1] + targetDir.right * targetDistance, ref segmentV, smoothSpeed + i / trailSpeed);
    }
    lineRend.SetPositions(segmentPoses);
  }
}



using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class TentaclesLineRenderer : MonoBehaviour{
  
  public int length;
  private Vector3[] segmentPoses;
  private LineRenderer lineRend;
  public Transform targetDir;
  public float targetDistance;
  private Vector3[] segmentV;
  public float smoothSpeed;
  
  public float wiggleSpeed;
  public float wiggleMagnitude;
  public Transform wiggleDir;
  
  void Start(){
    lineRend = GetComponent<LineRenderer>();
    segmentPoses = new Vector3[length];
    lineRend.positionCount = length;
    ResetPos();
  }
  
  void Update(){
    
    wiggleDir.localRotation = Quaternion.Euler(0f, 0f, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);
    
    segmentPoses[0] = targetDir;
    for(int i=1; i<segmentPoses.Length; i++){
      Vector3 targetPos = segmentPoses[i-1] + (segmentPoses[i] - segmentPoses[i-1]).normalized * targetDistance;
      segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i], targetPos, ref segmentV[i], smoothSpeed);
    }
    lineRend.SetPositions(segmentPoses);
  }
  
  void ResetPos(){
    segmentPoses[0] = targetDir;
    for(int i=1; i<segmentPoses.Length; i++){
      segmentPoses[i] = segmentPoses[i-1] + targetDir.right * targetDistance;
    }
    lineRend.SetPositions(segmentPoses);
  }
}