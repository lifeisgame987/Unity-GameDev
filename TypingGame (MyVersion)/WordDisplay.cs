using System.Collections;
using System.Collections.Generics;
using UnityEngine;
using UnityEngine.UI;

public class  : MonoBehaviour{
  
  public Text text;
  public float speed = 20f;
  
  void Update(){
    transform.Translate(Vector3.down * speed * Time.deltaTime);
  }
  
  public void SetWord(string word){
    text.text = word;
  }
  
  public void RemoveLetter(){
    text.text = text.text.Remove(0, 1)
  }
  
  public void RemoveWord(){
    Destroy(gameObject);
  }
}