using System.Collections;
using System.Collections.Generics;
using UnityEngine;

[System.Serializable]
public class Classes{
  public int itemId;
  public string itemName;
  public string itemDescription;
}

[System.Serializable]
public class Asl{
  public int age;
  public string sex;
  public string location;
}



// Another class
using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class Player : MonoBehaviour{
  
  public Classes[] classes;
  public Asl asl;
  
  void Start(){
    
  }
  
  void Update(){
    
  }
}