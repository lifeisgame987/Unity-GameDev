using UnityEngine;

public class Card : MonoBehaviour{
  
  [SerializeField] private CardSO cardSO;
  [SerializeField] private CardAnimator cardAnimator;
  
  public int CardId {get; private set;}
  
  private void Start(){
    CardId = cardSO.Id;
  }
  
  public CardAnimator GetCardAnimator(){
    return cardAnimator;
  }
  
  public void DestroySelf(){
    Destroy(gameObject);
  }
}

using UnityEngine;

public class CardAnimator : MonoBehaviour{
  
  private const string OPEN_CARD = "IsOpened";
  private const string IS_OPENED = "Opened";
  private const string IS_CLOSED = "Closed";
  
  private Animator animator;
  
  private bool isOpened;
  private bool isClosed;
  
  private void Awake(){
    animator = GetComponent<Animator>();
  }
  
  private void Update(){
    isOpened = animator.GetCurrentAnimatorStateInfo(0).IsName(IS_OPENED);
    isClosed = animator.GetCurrentAnimatorStateInfo(0).IsName(IS_CLOSED);
  }
  
  public void OpenCard(){
    animator.SetBool(OPEN_CARD, true);
  }
  
  public void CloseCard(){
    animator.SetBool(OPEN_CARD, false);
  }
  
  public bool IsOpened(){
    return isOpened;
  }
  
  public bool IsClosed(){
    return isClosed;
  }
}
