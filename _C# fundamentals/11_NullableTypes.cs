using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public string name = "Vicky";
  public int age = 21;
  public bool? isCool;
  
  void Start(){
    isCool = null;
    
    if(isCool != null){
      Debug.Log("Not null");
    }
    else{
      Debug.Log("Null value");
    }
  }
  
  void Update(){
    if(Input.GetKeyDown(KeyCode.Space)){
      CreateUser("Vicky", null, true);
    }
  }
  
  void CreateUser(string name, int? age, bool isCool){
    Debug.Log("Name : " + name);
    Debug.Log("Age : " + age ?? 18);
    Debug.Log("IsCool : " + isCool);
  }
}