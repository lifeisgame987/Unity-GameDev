using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public Rigidbody2D hookRB;
  public GameObject linkPrefab;
  public int links = 10;
  public Weight weight;
  
  void Start(){
    GenerateRope();
  }
  
  void GenerateRope(){
    
    Rigidbody2D previousRB = hook;
    
    for(int i=0; i<links; i++){
      GameObject link = Instantiate(linkPrefab, transform);
      HingeJoint2D linkJoint = link.GetComponent<HingeJoint2D>();
      linkJoint.connectedBody = previousRB;
      
      if(i < links-1){
        previousRB = link.GetComponent<Rigidbody2D>();
      }
      else{
        weight.SetWeight(link.GetComponent<Rigidbody2D>());
      }
    }
  }
}