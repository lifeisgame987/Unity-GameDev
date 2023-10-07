// This object must be in MainMenu Scene for clearing static fields/events
using UnityEngine;

public class ResetStaticDataManager : MonoBehaviour{
  
  private void Awake(){
    OtherClass.ResetStaticData();
  }
}



using UnityEngine;

public class OtherClass : MonoBehaviour{
  
  public static event EventHandler OnAnyEventFired;
  // For static fields/events (except class Instance, methods) 
  // it doesn't get cleaned/destroyed/reset on scene changes,
  // so we have to manually clean it in the MainMenu
  public static void ResetStaticData(){
    OnAnyEventFired = null;
  }
}
