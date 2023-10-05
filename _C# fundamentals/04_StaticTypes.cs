using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticTypes{
  // static class cannot inherit classes or implement inheritance
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticTypes : MonoBehaviour{
  
  public static int MyInt;
  
  public static void MyFunction(){
    
  }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  : MonoBehaviour{
  
  void Start(){
    StaticTypes.MyInt = 0;
    StaticTypes.MyFunction();
  }
} // Not efficient as static types takes up the  memory and remains till the lifetime of the application