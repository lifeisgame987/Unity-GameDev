using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class CameraFollow : MonoBehaviour{
  
  [SerializeField] private float minX;
  [SerializeField] private float maxX;
  [SerializeField] private float minY;
  [SerializeField] private float maxY;
  [SerializeField] private float speed;
  [SerializeField] private Transform player;
  
  void Start(){
    transform.position = player.position;
  }
  
  void Update(){
    if(player != null){
      float newX = Mathf.Clamp(player.positiin.x, minX, maxX);
      float newY = Mathf.Clamp(player.position.y, minY, maxY);
      transform.position = Vector2.Lerp(transform.position, new Vector2(newX, newY), speed);
    }
  }
}