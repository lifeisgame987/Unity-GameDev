using UnityEngine;

public class Card : MonoBehaviour{
  
  [SerializeField] private CardSO cardSO;
  [SerializeField] private CardTween cardTween;
  
  public int CardId {get; private set;}
  
  private void Start(){
    CardId = cardSO.Id;
  }
  
  public CardTween GetCardTween(){
    return cardTween;
  }
  
  public void DestroySelf(){
    Destroy(gameObject);
  }
}

using UnityEngine;

public class CardVisuals : MonoBehaviour{
  
  [SerializeField] private GameObject targetToRotate;
  [SerializeField] private GameObject cardBack;
  
  [SerializeField] private float openTweenTime;
  [SerializeField] private float closeTweenTime;
  
  private LTDescr openTween;
  private LTDescr closeTween;
  
  private bool isOpened = false;
  private bool isClosed = false;
  
  private void Start(){
    OpenAndClose();
  }
  
  private void Update(){
    if(openTween.passed >= (openTween.time / 2)){
      cardBack.SetActive(false);
    }
    
    if(closeTween.passed >= (closeTween.time / 2)){
      cardBack.SetActive(true);
    }
  }
  
  public void OpenAndClose(){
    OpenCardTween();
    ClosedCard();
    closeTween.setDelay(openTweenTime);
    closeTween.setOnComplete(TurnOffOpen);
  }
  
  public void OpenCard(){
    OpenCardTween();
    openTween.setOnComplete(TurnOnOpen);
  }
  
  public void ClosedCard(){
    CloseCardTween();
    closeTween.setOnComplete(TurnOffOpen);
  }
  
  private void OpenCardTween(){
    Vector3 rotation = new Vector3(0f, 180f, 0f);
    openTween = LeanTween.rotateLocal(targetToRotate, rotation, openTweenTime)
  }
  
  private void CloseCardTween(){
    Vector3 rotation = new Vector3(0f, 0f, 0f);
    closeTween = LeanTween.rotateLocal(targetToRotate, rotation, closeTweenTime)
  }
  
  private void TurnOnOpen(){
    isOpened = true;
    isClosed = false;
  }
  
  private void TurnOffOpen(){
    isOpened = false;
    isClosed = true;
  }
  
  public bool IsOpened(){
    return isOpened;
  }
  
  public bool IsClosed(){
    return isClosed;
  }
}