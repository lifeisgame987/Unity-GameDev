using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helper{
  public class Position{
    
    public static Vector3 SetPositionToZero(){
      return Vector3.zero;
    }
  }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities{
  
  public static Vector3 SetPositionToZero(){
    return Vector3.zero;
  }
}



// Adding extension to predefined classes
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities{
  
  public static Vector3 SetTransformPositionToZero(this Transform trans){
    trans.position = Vector3.zero;
    return trans.position;
  }
}



// Another script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Helper;

public class  : MonoBehaviour{
  
  void Start(){
    
    // Using namespaces
    transform.position = Position.SetPositionToZero();
    
    // Using static class
    transform.position = Utilities.SetPositionToZero();
    
    // Using extension of predefined classes
    transform.position = transform.SetTransformPositionToZero();
  }
}