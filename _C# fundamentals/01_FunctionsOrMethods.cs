using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class  : MonoBehaviour{
  
  public int a = 4;
  public int b = 8;
  private int result;
  
  public GameObject cube;
  
  void Start(){
    
  }
  
  void Update(){
    if(Input.GetKeyDown(KeyCode.Space)){
      GameObjectPosition(this.gameObject, "Hi");
      
      result = Multiply(a, b);
      Debug.Log("Result: " + result);
      
      cube.GetComponent<Renderer>().material.color = ChangeColor(Color.red, cube, "John");
    }
  }
  
  void GameObjectPosition(GameObject ob, string m){
    Debug.Log(ob.transform.position + " " + m);
  }
  
  int Multiply(int a, int b){
    return a * b;
  }
  
  Color ChangeColor(Color col, GameObject ob, string name){
    ob.name = name;
    return col;
  }
}