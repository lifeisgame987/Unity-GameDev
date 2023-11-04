using UnityEngine;
using UnityEngine.UI;

public class CardUILockTween : MonoBehaviour{
  
  [SerializeField] private Loader.Scene currentLevel;
  [SerializeField] private Loader.Scene previousLevel;
  
  [SerializeField] private Button lockButton;
  [SerializeField] private Button startButton;
  
  private bool isCurrentCardUIOpen;
  private LevelData previousLeveldata;
  
  private void Awake(){
    if(currentLevel == Loader.Scene.MainMenu || currentLevel == Loader.Scene.Loading){
      Debug.LogError("Invalid Current Level Name: " + currentLevel);
      return;
    }
    
    if(previousLevel == Loader.Scene.MainMenu || previousLevel == Loader.Scene.Loading){
      Debug.LogError("Invalid Previous Level Name: " + previousLevel);
      return;
    }
    
    isCurrentCardUIOpen = Saver.LoadCardUIOpen(currentLevel.ToString());
    previousLeveldata = Saver.LoadLevelData(previousLevel.ToString());
    
    startButton.onClick.AddListener(() => {
      Loader.Load(currentLevel);
    });
    
    if(isCurrentCardUIOpen){
      lockButton.gameObject.SetActive(false);
      cardBack.SetActive(false);
      cardVisualsHolder.rotation = Quaternion.identity;
      startButton.gameObject.SetActive(true);
      return;
    }
    
    startButton.gameObject.SetActive(false);
    
    lockButton.onClick.AddListener(() => {
      if(previousLeveldata.IsLevelCompleted){
        Saver.SaveCardUIOpen(currentLevel.ToString(), true);
        GetComponent<CardUITween>().enabled = true;
      }
    });
  }
  
  private void Start(){
    if(isCurrentCardUIOpen) return;
    
    if(previousLeveldata.IsLevelCompleted){
      ClickLockTween();
    }
    else{
      lockButton.GetComponent<RectTransform>().rotation = Quaternion.identity;
    }
  }
  
  private void ClickLockTween(){
    // Tween
  }
}