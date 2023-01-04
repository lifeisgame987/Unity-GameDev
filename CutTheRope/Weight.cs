using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class Weight : MonoBehaviour{
  
  public float distance = 0.6f;
  
  public void SetWeight(Rigidbody2D rb){
    HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
    joint.connectedBody = rb;
    joint.autoConfigureConnectedAnchor = false;
    joint.anchor = Vector2.zero;
    joint.connectedAnchor = new Vector2(0f, -distance);
  }
}