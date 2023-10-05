using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properties : MonoBehaviour{
  
  // Standard FIELD
  private int _myAge = 21;
  
  public int MyAge{
    get{
      return _myAge;
    }
    set{
      _myAge = value;
    }
  }
  
  
  // Auto property
  public int MySalary{get; set;}
  public int MyNumber{get; private set;}
  public int MyNumber{get; protected set;}
}



// Another class
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
  
  private Properties myProperties;
  
  void Start(){
    myProperties = new Properties();
    Debug.Log(myProperties.MyAge);
    myProperties.MyAge = 88;
    
    myProperties.MySalary = 50000;
    Debug.Log(myProperties.MySalary);
  }
}