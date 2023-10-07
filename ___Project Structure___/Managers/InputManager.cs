using UnityEngine;

public class InputManager : MonoBehaviour{
  
  public static InputManager Instance {get; private set;}
  
  // Fire own events that requires to subscribe the underlying InputActions event
  
  // Declare InputActions Instance
  
  private void Awake(){
    Instance = this;
    
    // Create Instance of InputActions Object that is automatically generated
    // Enable InputActions
    
    // Subscribe to InputActions (New Input System)
  }
  
  private void OnDestroy(){
    // Unsubscribe to InputActions (New Input System)
    
    // Dispose InputActions
  }
}