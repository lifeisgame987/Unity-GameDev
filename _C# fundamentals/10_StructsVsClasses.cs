using System.Collections;
using System.Collections.Generics;
using UnityEngine;

[System.Serializable]
public class Book{
  public int price;
  public string title;
  public string author;
  
  public Book(int p, string t, string a){
    this.price = p;
    this.title = t;
    this.author = a;
  }
}

[System.Serializable]
public struct Book{
  public int price;
  public string title;
  public string author;
}

public class StructsVsClasses : MonoBehaviour{
  
  public Book classBook;
  public Book structBook;
  
  void Start(){
    classBook = new Book(30, "Coding", "Soum");
    structBook.price = 30;
    structBook.title = "Coding";
    structBook.author = "Soum";
  }
}