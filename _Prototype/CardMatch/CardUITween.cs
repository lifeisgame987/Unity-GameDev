public class CardUITween : MonoBehaviour{
  
  [SerializeField] private GameObject lockButton;
  [SerializeField] private RectTransform cardVisualsHolder;
  [SerializeField] private GameObject cardBack;
  [SerializeField] private GameObject startButton;
  
  private void Start(){
    UnlockTween();
  }
  
  private void UnlockTween(){
    // Tween
  }
  
  private void StartCardUITween(){
    lockButton.SetActive(false);
    // Tween
  }
  
  private void NextHalfCardUITween(){
    cardBack.SetActive(false);
    startButton.SetActive(true);
    // Tween
  }
}