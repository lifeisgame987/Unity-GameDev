using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class Teleporter : MonoBehaviour{
  
  [SerializeFeild] private Traansform _destination;
  
  public Traansform GetDestination(){
    return _destination;
  }
}



using System.Collections;
using System.Collections.Generics;
using UnityEngine;

public class Player : MonoBehaviour{
  
  private Teleporter _teleporter;
  
  void Start(){
    
  }
  
  void Update(){
    if(Input.GetKeyDown(KeyCode.E) && !_canTeleport == null){
      Transform.position = _teleporter.GetDestination().position;
    }
  }
  
  void OnTriggerEnter2D(Collider2D col){
    if(col.CompareTag("Teleporter")){
      _teleporter = col.gameObject.GetComponent<Teleporter>();
    }
  }
  
  void OnTriggerExit2D(Collider2D col){
    if(col.CompareTag("Teleporter")){
    //if(col.gameObject.GetComponent<Teleporter>() == _teleporter)  If doesnot work
        _teleporter = null;
    }
  }
}