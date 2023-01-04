using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public Rigidbody2D rb;
  public Vector2 startForce;
  public GameObject ball;
  
  void Start(){
    rb.AddForce(startForce, ForceMode2D.Impulse);
  }
  
  public void Split(){
    if(ball != null){
      GameObject ball1 = Instantiate(ball, rb.position + Vector2.right / 4f, Quaternion.Identity);
      GameObject ball2 = Instantiate(ball, rb.position + Vector2.left / 4f, Quaternion.Identity);
      
      ball1.GetComponent<Ball>().startForce = new Vector2(2f, 5f);
      ball2.GetComponent<Ball>().startForce = new Vector2(-2f, 5f);
    }
    
    Destroy(gameObject);
  }
}