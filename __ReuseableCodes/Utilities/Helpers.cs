using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// This is a helper class which will help with certain functions
/// that we have to do it regularly so in order to be performance
/// specific we use this class. As it is a static class it means
/// that this class can not be instantiated and it will contain
/// only static members
/// </summary>
public static class Helpers{
  
  /// <summary>
  /// This will help us to take camera reference once in the
  /// script which will be very handy performance wise, as in
  /// traditional way it will find camera object out of all
  /// objects available which is a bad practice and even affects
  /// performance
  /// </summary>
  private static Camera _camera;
  public static Camera Camera{
    get{
      if(_camera == null) _camera = Camera.main;
      return _camera;
    }
  }
  
  /// <summary>
  /// This is helpful in coroutines as we have to yield
  /// waitforseconds it will allocate memory resources and the
  /// garbage collector has to come to clean it out which is
  /// also not performance handy, therefore we cache it out to
  /// avoid memory allocation
  /// </summary>
  private static readonly Dictionary<float, WaitForSeconds> _waitDictionary = Dictionary<float, WaitForSeconds>();
  public static WaitForSeconds GetWait(float time){
    if(_waitDictionary.TryGetValue(time, out var wait)) return wait;
    _waitDictionary[time] = new WaitForSeconds(time);
    return _waitDictionary[time];
  }
  
  /// <summary>
  /// This is helpful to know whether we are clicking an Ui
  /// element or the actual game scene as for example when we
  /// press pause button we dont want the character to jump so
  /// in that case it is very useful
  /// </summary>
  private static PointerEventData _eventDataCurrentPosition;
  private static List<RaycastResult> _results;
  public static bool IsOverUi(){
    _eventDataCurrentPosition = new PointerEventData(EventSystem.current){position = Input.mousePosition};
    _results = new List<RaycastResult>();
    EventSystem.current.RaycastAll(_eventDataCurrentPosition, _results);
    return _results.Count > 0;
  }
  
  /// <summary>
  /// This is useful when we want to spawn any particles or
  /// units according to the position of our canvas in world
  /// coordinates
  /// </summary>
  public static Vector2 GetWorldPointOfCanvasElement(RectTransform element){
    RectTransformUtility.ScreenPointToWorldPointInRectangle(element, element.position, Camera, out var result);
    return result;
  }
  
  /// <summary>
  /// This is helpful as in game we have to destroy objects which
  /// may have children in it so it is quite handy to use this as
  /// it will destroy children all at once rather than doing it
  /// manually
  /// </summary>
  public static void Destroy Children(this Tansform t){
    foreach(Transform child in t) Object.Destroy(child.gameObject);
  }
}