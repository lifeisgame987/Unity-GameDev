// If you want your object to receive events even in disabled
// stateChanged then subscribe/unsubscribe in OnStart/OnDestroy

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegatesAndEvents : MonoBehaviour{
  
  // C# standard event
  public event EventHandler OnStateChanged;
  
  // C# standard event with arguments
  public event EventHandler<OnAnotherStateChangedEventArgs> OnAnotherStateChanged;
  public class OnAnotherStateChangedEventArgs{
    public int Id;
  }
  
  private void Update(){
    if(stateChanged){
      OnStateChanged?.Invoke(this, EventArgs.Empty);
    }
    if(anotherStateChanged){
      OnAnotherStateChanged?.Invoke(this, new OnAnotherStateChangedEventArgs{
        Id = 1;
      });
    }
  }
}


// Another script
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  : MonoBehaviour{
  
  [SerializeField] public DelegatesAndEvents del;
  
  private void OnEnable(){
    del.OnStateChanged += DoSomething;
    del.OnAnotherStateChanged += DoSomethingAgain;
  }
  
  private void OnDisable(){
    del.OnStateChanged -= DoSomething;
    del.OnAnotherStateChanged -= DoSomethingAgain;
  }
  
  private void DoSomething(Objecct sender, System.EventArgs e){
    // Do something
  }
  
  private void DoSomethingAgain(Object sender, DelegatesAndEvents.OnAnotherStateChangedEventArgs e){
      if(e.Id == 1){
        // Do something
      }
    }
}