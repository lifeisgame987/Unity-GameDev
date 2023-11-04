

namespace VickyBhatt{
  public static class Help{
    
    public static bool IsPointerOverUI() {
      if (EventSystem.current.IsPointerOverGameObject()) {
        return true;
      }
      else {
        PointerEventData pe = new PointerEventData(EventSystem.current);
        pe.position =  Input.mousePosition;
        List<RaycastResult> hits = new List<RaycastResult>();
        EventSystem.current.RaycastAll( pe, hits );
        return hits.Count > 0;
      }
    }
    
    
  }
}