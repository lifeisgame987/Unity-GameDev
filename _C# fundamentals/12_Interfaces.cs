using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public interface Idamageable<T>{
  
  void Damage(T damage);
  
}

public interface Ihealable{
  
  int health{get; set;}
  
}


// Another script
using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class Player : MonoBehaviour, Idamageable<float>, Ihealable{
  
  public int health{get; set;}
  
  public void Damage(float damage){
    
  }
}


// Another script
using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class Enemy : MonoBehaviour, Idamageable<int>{
  
  public void Damage(int damage){
    
  }
}